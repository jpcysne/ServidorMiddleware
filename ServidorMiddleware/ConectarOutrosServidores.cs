﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorMiddleware
{
    public class ConectarOutrosServidores
    {
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado = false;
        FormMiddleware form;
        private int memoriaSplit;
        private int cpuSplit;
        private string[] checkStream;
        public ConectarOutrosServidores()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            /* se não esta conectando aguarda a conexão
            if (Conectado == false)
            {
                // Inicializa a conexão
                InicializaConexao(ip);
            }
            else // Se esta conectado entao desconecta
            {
                FechaConexao("Desconectado a pedido do usuário.");
            }*/

        }
        public void InicializaConexao(string ip)
        {

            try
            {
                // Trata o endereço IP informado em um objeto IPAdress
                enderecoIP = IPAddress.Parse(ip);
                // Inicia uma nova conexão TCP com o servidor chat
                tcpServidor = new TcpClient();
                tcpServidor.Connect(enderecoIP, 2502);

                // AJuda a verificar se estamos conectados ou não
                Conectado = true;


                // Envia o valor da CPU e Memoria ao servidor

                stwEnviador = new StreamWriter(tcpServidor.GetStream());
                stwEnviador.WriteLine(form.CPUTXT.Text + "-" + form.MemoriaTXT.Text);
                stwEnviador.Flush();

                //Inicia a thread para receber mensagens e nova comunicação
                mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
                mensagemThread.Start();
            }
            catch (Exception ex)
            {
                form.AtualizaStatus("Erro : " + ex.Message + "Erro na conexão com servidor");
            }
        }

        private void RecebeMensagens()
        {
            // recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            
            // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                form.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
                

            }
            else // Se o primeiro caractere não for 1 a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3o caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                form.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                try
                {
                    ConResposta = strReceptor.ReadLine();
                    checkStream = ConResposta.Split('-');
                    if (checkStream[0].Equals('2'))
                    {
                        memoriaSplit = Convert.ToInt32(checkStream[1]);
                        cpuSplit = Convert.ToInt32(checkStream[2]);

                        EnviaMensagem(memoriaSplit,cpuSplit);
                    }
                    if (checkStream[0].Equals('3'))
                    {
                        memoriaSplit = Convert.ToInt32(checkStream[1]);
                        cpuSplit = Convert.ToInt32(checkStream[2]);

                        RecursoCaptado(memoriaSplit, cpuSplit);
                    }
                    // exibe mensagems no Textbox
                    form.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });

                }
                catch (Exception e)
                {
                    FechaConexao("Desconectado");
                }
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            form.txtServidor.AppendText(strMensagem + "\r\n");
        }

        // Envia a mensagem para o servidor
        private void EnviaMensagem(int memoria, int cpu)
        {

            stwEnviador.WriteLine(form.CPUPossuiTXT.Text + "-" + form.MEMPossuiTXT.Text);
            stwEnviador.Flush();

        }

        private void RecursoBloqueado()
        {

        }

        private void RecursoCaptado(int memoriaRecurso, int cpuRecurso)
        {
            ///aqui ele recebe o recurso, coloca no bloqueio desse servidor o recurso pedido
            
            if (memoriaRecurso <= (Convert.ToInt32(form.MEMPossuiTXT.ToString())) 
                || (cpuRecurso <= Convert.ToInt32(form.CPUPossuiTXT.ToString())))
            {
                if((Convert.ToInt32(form.MEMBloqueioTXT.ToString()) < Convert.ToInt32(form.MEMPossuiTXT.ToString()))
                    || (Convert.ToInt32(form.CPUBloqueioTXT.ToString()) < Convert.ToInt32(form.CPUPossuiTXT.ToString())))
                {
                    cpuRecurso = Convert.ToInt32(form.CPUBloqueioTXT) + cpuRecurso;
                    memoriaRecurso = Convert.ToInt32(form.MEMBloqueioTXT) + memoriaRecurso;
                    form.MEMBloqueioTXT.Text = memoriaRecurso.ToString();
                    form.CPUBloqueioTXT.Text = cpuRecurso.ToString();


                }else
                {
                    stwEnviador.WriteLine("Recurso Indisponivel");
                    stwEnviador.Flush();
                }
            }else
            {
                stwEnviador.WriteLine("Recurso Indisponivel");
                stwEnviador.Flush();
            }

            

        }

        private void FechaConexao(string Motivo)
        {


            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
            mensagemThread.Interrupt();
        }

        // O tratador de evento para a saida da aplicação
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado == true)
            {
                // Fecha as conexões, streams, etc...
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }

        
    }
}

