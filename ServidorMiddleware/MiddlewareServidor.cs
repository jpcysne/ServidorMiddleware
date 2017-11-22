using ServidorMiddleware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ServidorMiddleware
{
        // Este delegate é necessário para especificar os parametros que estamos passando com o nosso evento
        public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);
        

    public class MiddlewareServidor
    {
        // Esta hash table armazena os usuários e as conexões (acessado/consultado por usuário)
            public static Hashtable htUsuarios = new Hashtable(30);
            public static Hashtable htConexoes = new Hashtable(30); 
                                                                    
            public static Hashtable htMemoria = new Hashtable(30); // armazena o IP/Memoria
            public static Hashtable htCPU = new Hashtable(30);      // armazena o IP/CPU
            private IPAddress enderecoIP;
            private TcpClient tcpCliente;
            // O evento e o seu argumento irá notificar o formulário quando um usuário se conecta, desconecta, envia uma mensagem,etc
            public static event StatusChangedEventHandler StatusChanged;
            public static event StatusChangedEventHandler CPUChanged;
            public static event StatusChangedEventHandler MemoriaChanged;
            private static StatusChangedEventArgs e;
            public static int TotalMemoria = 0;
            public static int TotalCPU = 0;
            public FormMiddleware fmd = new FormMiddleware();


        // O construtor define o endereço IP para aquele retornado pela instanciação do objeto
            public MiddlewareServidor(IPAddress endereco)
            {
                enderecoIP = endereco;
                
            }

        public MiddlewareServidor()
        {
        }

        // A thread que ira tratar o escutador de conexões
        private Thread thrListener;

            // O objeto TCP object que escuta as conexões
            private TcpListener tlsCliente;

            // Ira dizer ao laço while para manter a monitoração das conexões
            bool ServRodando = false;

            // Inclui o usuário nas tabelas hash
            public  void IncluiUsuario(TcpClient tcpUsuario, string strUsername, int memoria, int cpu)
            {
            // Primeiro inclui o nome e conexão associada para ambas as hash tables
                MiddlewareServidor.htUsuarios.Add(strUsername, tcpUsuario);
                MiddlewareServidor.htConexoes.Add(tcpUsuario, strUsername);
                MiddlewareServidor.htMemoria.Add(tcpUsuario,memoria);
                MiddlewareServidor.htCPU.Add(tcpUsuario, cpu);
                fmd.comboBoxServidores.Items.Add(htUsuarios.Keys);
                // Informa a nova conexão para todos os usuário e para o formulário do servidor
                EnviaMensagemAdmin(htMemoria[tcpUsuario] + " entrou..");
                Somatorio();
            }

            public ArrayList ListarUsuarios()
            {
                ArrayList servidores = new ArrayList(htUsuarios.Keys);
                return servidores;
            }

            // Remove o usuário das tabelas (hash tables)
            public  void RemoveUsuario(TcpClient tcpUsuario)
            {
                // Se o usuário existir
                if (htMemoria[tcpUsuario] != null)
                {
                    // Primeiro mostra a informação e informa os outros usuários sobre a conexão
                    EnviaMensagemAdmin(htMemoria[tcpUsuario] + " saiu...");
                
                    // Removeo usuário da hash table
                    MiddlewareServidor.htUsuarios.Remove(MiddlewareServidor.htConexoes[tcpUsuario]);
                    MiddlewareServidor.htConexoes.Remove(tcpUsuario);
                    MiddlewareServidor.htMemoria.Remove(tcpUsuario);
                    MiddlewareServidor.htCPU.Remove(tcpUsuario);
                    fmd.comboBoxServidores.Items.Remove(htUsuarios.Keys);
                    Subtrair();
                }
            }

            // Este evento é chamado quando queremos disparar o evento StatusChanged
            public static void OnStatusChanged(StatusChangedEventArgs e)
            {
                StatusChangedEventHandler statusHandler = StatusChanged;
                if (statusHandler != null)
                {
                    // invoca o  delegate
                    statusHandler(null, e);
                
                }
            }

            public static void OnMemorieChanged(StatusChangedEventArgs e)
            {
                StatusChangedEventHandler memoriaHandler = MemoriaChanged;
                if (memoriaHandler != null)
                {
                // invoca o  delegate
                    memoriaHandler(null, e);
                }
            }

            public static void OnCPUChanged(StatusChangedEventArgs e)
            {
                StatusChangedEventHandler CPUHandler = CPUChanged;
                if (CPUHandler != null)
                {
                    // invoca o  delegate
                    CPUHandler(null, e);
                }
            }



        public void Atualizar(string memoria, string cpu)
            {
            
                StreamWriter swSenderSender;

                // Cria um array de clientes TCPs do tamanho do numero de clientes existentes
                TcpClient[] tcpClientes = new TcpClient[MiddlewareServidor.htConexoes.Count];
                // Copia os objetos TcpClient no array
                MiddlewareServidor.htUsuarios.Values.CopyTo(tcpClientes, 0);
                // Percorre a lista de clientes TCP
                for (int i = 0; i < tcpClientes.Length; i++)
                {
                    // Tenta enviar uma mensagem para cada cliente
                    try
                    {
                        
                        // Envia a mensagem para o usuário atual no laço
                        swSenderSender = new StreamWriter(tcpClientes[i].GetStream());
                        swSenderSender.WriteLine("2"+"-"+  memoria +"-"+ cpu);
                        swSenderSender.Flush();
                        swSenderSender = null;
                    }
                    catch // Se houver um problema , o usuário não existe , então remove-o
                    {
                        RemoveUsuario(tcpClientes[i]);
                    }
                }
             }

            // Envia mensagens administratias
            public static void EnviaMensagemAdmin(string Mensagem)
            {
 
                // Exibe primeiro na aplicação
                e = new StatusChangedEventArgs("Administrador: " + Mensagem);
                OnStatusChanged(e);
            }

            // Recebe mensagens de um usuário 
            public  void ReceberMensagem(TcpClient tcpUsuario, string Origem, string Mensagem)
            {
                

                // Primeiro exibe a mensagem na aplicação
                e = new StatusChangedEventArgs(Origem + " disse : " + Mensagem);
                OnStatusChanged(e);
                int cpuRecebida= int.Parse(Mensagem.Split('-')[0]);
                int memoriaRecebida = int.Parse(Mensagem.Split('-')[1]);
            
                MiddlewareServidor.htCPU[tcpUsuario] = cpuRecebida;
                MiddlewareServidor.htMemoria[tcpUsuario] = memoriaRecebida;
                Somatorio();
                
            }
             public  void Subtrair()
             {
                if(TotalMemoria >= 0)
                {
                    TotalMemoria = 0;
                }
           
                if(TotalCPU >= 0)
                {
                    TotalCPU = 0;
                }
                Somatorio();
            }
        
            public void Somatorio()
            {
                TotalCPU = 0;
                TotalMemoria = 0;
                // Percorre a lista de clientes TCP
                foreach(int memoria in htMemoria.Values)
                {
                    TotalMemoria += memoria;
                }
                foreach(int cpu in htCPU.Values)
                {
                    TotalCPU += cpu;
                }

            e = new StatusChangedEventArgs("CPU = " + TotalCPU + " Memoria= " + TotalMemoria);
            OnStatusChanged(e);
            e = new StatusChangedEventArgs(TotalCPU + "-");
            OnCPUChanged(e);
            e = new StatusChangedEventArgs(TotalMemoria + "-");
            OnMemorieChanged(e);


        }
        
            public void IniciaAtendimento()
            {
                try
                {

                    // Pega o IP do primeiro dispostivo da rede
                    IPAddress ipaLocal = enderecoIP;

                    // Cria um objeto TCP listener usando o IP do servidor e porta definidas
                    tlsCliente = new TcpListener(ipaLocal, 2502);

                    // Inicia o TCP listener e escuta as conexões
                    tlsCliente.Start();

                    // O laço While verifica se o servidor esta rodando antes de checar as conexões
                    ServRodando = true;

                    // Inicia uma nova tread que hospeda o listener
                    thrListener = new Thread(MantemAtendimento);
                    thrListener.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            private void MantemAtendimento()
            {
                // Enquanto o servidor estiver rodando
                while (ServRodando == true)
                {
                    // Aceita uma conexão pendente
                    tcpCliente = tlsCliente.AcceptTcpClient();
                    // Cria uma nova instância da conexão
                    Conexao newConnection = new Conexao(tcpCliente);
                }
            }
        }
    
    }

