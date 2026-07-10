namespace CirculoDeTusi
{
    using CirculoDeTusi.Calculos;
    using System.Drawing;          // Contém as ferramentas de desenho (canetas, pincéis, cores)
    using System.Windows.Forms;    // Contém a janela, os eventos de teclado/mouse e o Timer

    public partial class frmEfeitoTusi : Form
    {
        
        private Timer relogioJanela;
        private CalculoHMS Hms = new CalculoHMS();
        //---------------------------------------
        private Brush pincel_Fundo;
        private Brush pincel_CirculosBrancos;
        private Pen caneta_LinhaGuia;

        public frmEfeitoTusi()
        {
            InitializeComponent();
        }

        private void frmEfeitoTusi_Load(object sender, EventArgs e)
        {
            SetupInicial();

            // 1. Instanciamos o nosso relógio
            relogioJanela = new Timer();

            // 2. Definimos o intervalo em milissegundos (16ms equivale a cerca de 60 quadros por segundo)
            relogioJanela.Interval = 16;

            // 3. Dizemos ao C# qual função deve ser executada a cada "tique" do relógio
            relogioJanela.Tick += RelogioJanela_Tick;

            // 4. Ativamos o recurso de DoubleBuffered para evitar que a tela fique piscando (o famoso "flicker")
            this.DoubleBuffered = true;

            // 5. Ligamos o relógio (o loop começa aqui!)
            relogioJanela.Start();

            this.Paint += frmEfeitoTusi_Paint;
        }

        private void frmEfeitoTusi_Paint(object? sender, PaintEventArgs e)
        {
            Hms.TotalCirculosMenores = (int)TotalCirculos.Value;
            DesenharCirculoDeTusi(e);
        }

        private void SetupInicial()
        {

            //Criar os pincéis e canetas (as cores que vai usar)
            //'Brush' preenche formas
            //'Pen' desenha o contorno (linhas)

            pincel_Fundo = new SolidBrush(Color.FromArgb(180, 0, 0));
            pincel_CirculosBrancos = Brushes.White;
            caneta_LinhaGuia = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
            
            //--------------------------------------------------
            
            Hms.RaioCirculoMaior = 300;
            Hms.AlturaJanela = this.ClientSize.Height;
            Hms.LarguraJanela = this.ClientSize.Width;
            Hms.TotalCirculosMenores = 8;
            Hms.TempoAnimacao = 0f;
        }

        private void DesenharCirculoDeTusi(PaintEventArgs e)
        {
            //01- O objeto 'g' é a sua tela de pintura (o seu canvas)
            //02- Ativa a suavização de serrilhado (Anti-aliasing) para círculos perfeitos
            //03- Limpa a tela com uma cor de fundo (substitui o CLS)

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            //CIRCULO PREENCHIDO
            if (chkExibirCirculo.Checked)
            {
                g.FillEllipse(pincel_Fundo, Hms.GetCirculoMaior_X(), Hms.GetCirculoMaior_Y(), Hms.GetCirculoMaior_Largura(), Hms.GetCirculoMaior_Altura());
            }

            for (int linhaAtual = 0; linhaAtual < Hms.TotalCirculosMenores; linhaAtual++)
            {
                float anguloAtual = Hms.GetAnguloAtual(linhaAtual);

                if (chkExibirLinhas.Checked)
                {
                    g.DrawLine(caneta_LinhaGuia, Hms.GetExtremidadeLinha_X1(anguloAtual),
                                                Hms.GetExtremidadeLinha_Y1(anguloAtual),
                                                Hms.GetExtremidadeLinha_X2(anguloAtual),
                                                Hms.GetExtremidadeLinha_Y2(anguloAtual));
                }

                float distanciaAtual = Hms.GetDistanciaEntreCirculos(anguloAtual);

                g.FillEllipse(pincel_CirculosBrancos, Hms.GetCirculoMenor_X(anguloAtual, distanciaAtual),
                                                      Hms.GetCirculoMenor_Y(anguloAtual,distanciaAtual),
                                                      Hms.GetCirculoMenor_Largura(),
                                                      Hms.GetCirculoMenor_Altura()
                                                    );
            }
        }

        private void RelogioJanela_Tick(object? sender, EventArgs e)
        {
            //01  A cada tique do relógio, avançamos o tempo da animação (Aproximadamente 16ms por tique)
            //02  Pedimos para a janela se redesenhar (chamando o evento Paint)
            Hms.TempoAnimacao += 0.016f; 
            this.Invalidate();
        }
       
    }
}