using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServidorMiddleware
{
    class Conexao
    {
        TcpClient tcpCliente;
        // A thread que ira enviar a informação para o cliente
        private Thread thrSender;
        private StreamReader srReceptor;
        private StreamWriter swEnviador;
        private string informacaoAtual;
        private string strResposta;
        
        private string nomeServidor;
        public static int numeroServidor = 0;
        private int memoriaInicial = 0;
        private int cpuInicial = 0;
        MiddlewareServidor midServe = new MiddlewareServidor();
        // O construtor da classe que que toma a conexão TCP
        public Conexao(TcpClient tcpCon)
        {
            numeroServidor++;
            tcpCliente = tcpCon;
            // A thread que aceita o cliente e espera a mensagem
            thrSender = new Thread(AceitaCliente);
             
            // A thread chama o método AceitaCliente()
            thrSender.Start();
        }

        private void FechaConexao()
        {
            // Fecha os objetos abertos
            tcpCliente.Close();
            srReceptor.Close();
            swEnviador.Close();
            thrSender.Interrupt();
        }

        // Ocorre quando um novo cliente é aceito
        private void AceitaCliente()
        {
            srReceptor = new System.IO.StreamReader(tcpCliente.GetStream());
            swEnviador = new System.IO.StreamWriter(tcpCliente.GetStream());
           
            // Lê a informação da conta do cliente
            informacaoAtual = srReceptor.ReadLine();

            // temos uma resposta do cliente
            if (informacaoAtual != "")
            {
                nomeServidor = "Servidor " + numeroServidor;

                cpuInicial = Convert.ToInt32(informacaoAtual.Split('-')[0]);
                memoriaInicial = Convert.ToInt32(informacaoAtual.Split('-')[1]);
               
                // 1 => conectou com sucesso
                swEnviador.WriteLine("1");
                swEnviador.Flush();

                    // Inclui o usuário na hash table e inicia a escuta de suas mensagens
                    midServe.IncluiUsuario(tcpCliente, nomeServidor,memoriaInicial,cpuInicial);
                
            }
            else
            {
                FechaConexao();
                return;
            }

            try
            {
                // Continua aguardando por uma mensagem do usuário
                while ((strResposta = srReceptor.ReadLine()) != "")
                {
                    // Se for inválido remove-o
                    if (strResposta == null)
                    {
                        midServe.RemoveUsuario(tcpCliente);
                    }
                    else
                    {

                        // envia a mensagem para todos os outros usuários
                        midServe.ReceberMensagem(tcpCliente,informacaoAtual, strResposta);
                    }
                }
            }
            catch
            {
                // Se houve um problema com este usuário desconecta-o
                midServe.RemoveUsuario(tcpCliente);
            }
        }
    }
}
