using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IdealSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApiService _apiService;
        private List<Cadastro> _cadastros;
        private Cadastro? _cadastroSelecionado;

        public MainWindow()
        {
            InitializeComponent();
            _apiService = new ApiService();
            _cadastros = new List<Cadastro>();
            LoadData();
        }

        private async void LoadData()//pega todos os ja cadastrados e lista eles
        {
            try
            {
                _cadastros = await _apiService.GetAllAsync();
                CadastroGrid.ItemsSource = _cadastros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private async void Salvar_Click(object sender, RoutedEventArgs e)//Tanto pra novo cadastro como para editar um antigo
        {
            try
            {
                var novoCadastro = new Cadastro
                {
                    Nome = txtNome.Text,
                    Sobrenome = txtSobrenome.Text,
                    Telefone = txtTelefone.Text
                };

                if (_cadastroSelecionado == null)
                {
                    await _apiService.CreateAsync(novoCadastro);
                    MessageBox.Show("Cadastro salvo com sucesso!");
                }
                else// Se algum formulario foi selecionado o save faz o edit
                {
                    novoCadastro.Id = _cadastroSelecionado.Id;
                    await _apiService.UpdateAsync(_cadastroSelecionado.Id, novoCadastro);
                    MessageBox.Show("Cadastro atualizado com sucesso!");
                    _cadastroSelecionado = null;
                }

                LimparFormulario();// Para limpar o front do formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cadastro: {ex.Message}");
            }
        }

        private void Editar_Click(object sender, RoutedEventArgs e)//Botão de edit na linha, não salva, apenas habilita a função
        {
            var button = sender as FrameworkElement;
            if (button?.Tag is Cadastro cadastro)
            {
                _cadastroSelecionado = cadastro;

                txtNome.Text = cadastro.Nome;
                txtSobrenome.Text = cadastro.Sobrenome;
                txtTelefone.Text = cadastro.Telefone;
            }
        }

        private async void Excluir_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            if (button?.Tag is Cadastro cadastro)
            {
                var confirm = MessageBox.Show("Tem certeza que deseja excluir este cadastro?", "Confirmação", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        await _apiService.DeleteAsync(cadastro.Id);
                        MessageBox.Show("Cadastro excluído com sucesso!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir cadastro: {ex.Message}");
                    }
                }
            }
        }

        private void LimparFormulario()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            _cadastroSelecionado = null;
            LoadData();
        }
    }
}