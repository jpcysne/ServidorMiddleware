using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServidorMiddleware
{
    public partial class FormMiddleware : Form
    {
        public string mem;
        public string proc;
        private delegate void AtualizaStatusCallback(string strMensagem);
        public delegate void AtualizaMem(string memMensagem);
        public delegate void AtualizaCPU(string CPUMensagem);
        MiddlewareServidor mainServidor;

        
        public FormMiddleware()
        {
            
            InitializeComponent();
        }

        private void ConectarBotao_Click(object sender, EventArgs e)
        {
            if (IPTXT.Text == string.Empty)
            {
                MessageBox.Show("Informe o endereço IP.");
                IPTXT.Focus();
                return;
            }

            try
            {

                // Analisa o endereço IP do servidor informado no textbox
                IPAddress enderecoIP = IPAddress.Parse(IPTXT.Text);

                // Cria uma nova instância do objeto MiddlewareServidor
                mainServidor = new MiddlewareServidor(enderecoIP);

                // Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
                MiddlewareServidor.StatusChanged += new StatusChangedEventHandler(mainServidor_StatusChanged);
                MiddlewareServidor.MemoriaChanged += new StatusChangedEventHandler(mainServidor_MemoriaChanged);
                MiddlewareServidor.CPUChanged += new StatusChangedEventHandler(mainServidor_CPUChanged);
                // Inicia o atendimento das conexões
                mainServidor.IniciaAtendimento();

                // Mostra que nos iniciamos o atendimento para conexões
                txtServidor.AppendText("Monitorando as conexões...\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão : " + ex.Message);
            }

        }

        public void mainServidor_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Chama o método que atualiza o formulário
            this.Invoke(new AtualizaStatusCallback(this.AtualizaStatus), new object[] { e.EventMessage });   
        }

        public void AtualizaStatus(string strMensagem)
        {
            // Atualiza o logo com mensagens
            txtServidor.AppendText(strMensagem + "\r\n");
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            mainServidor.Atualizar(MEMPossuiTXT.ToString() , CPUPossuiTXT.ToString());
        }

        public void mainServidor_MemoriaChanged(object sender, StatusChangedEventArgs e)
        {
           this.Invoke(new AtualizaMem(this.AtualizarMemoria), new object[] { e.EventMessage });
        }

        private void mainServidor_CPUChanged(object sender, StatusChangedEventArgs e)
        {
            this.Invoke(new AtualizaCPU(this.AtualizarCPU), new object[] { e.EventMessage });
        }
        // Memoria Total
        public void AtualizarMemoria(string memoriaString)
        {
            int TotalMemoria = Convert.ToInt32(memoriaString.Split('-')[0]);
            MemoriaTXT.Text = TotalMemoria.ToString(); 
        }
        //CPU Total
        public void AtualizarCPU(string CPUString)
        {
            int TotalCPU = Convert.ToInt32(CPUString.Split('-')[0]);
            CPUTXT.Text = TotalCPU.ToString(); 
        }

        private void BotaoMEMCPUAtual_Click(object sender, EventArgs e)
        {
            int memoriaAtual = Convert.ToInt32(MEMPossuiTXT.ToString()) + Convert.ToInt32(MemoriaTXT.ToString());
            MemoriaTXT.Text = memoriaAtual.ToString();
            int cpuAtual = Convert.ToInt32(CPUPossuiTXT.ToString()) + Convert.ToInt32(CPUTXT.ToString());
            CPUTXT.Text = cpuAtual.ToString();
        }

        private void ConectarOutroServ_Click(object sender, EventArgs e)
        {
            ConectarOutrosServidores conectarServ = new ConectarOutrosServidores();
            conectarServ.InicializaConexao(IPOutroServTXT.ToString());
        }

        private void BuscarServidores_Click(object sender, EventArgs e)
        {
            ArrayList servidores = mainServidor.ListarUsuarios();
            foreach(string serNomes in servidores)
            {
                comboBoxServidores.Items.Add(serNomes);


            }
        }
    }
}
