using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaAndrey
{
    public partial class Form1 : Form
    {
        //LISTA
        List<Nota> listaAnotacao = new List<Nota>();

        public Form1()
        {
            InitializeComponent();
            ID.Text = listaAnotacao.Count.ToString();
            ID.Enabled = false;

            preencherLista();
        }

        //METODO PARA SELECIONAR UMA ANOTAÇÃO
        private void lstNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nota notaSelecionada = lstNotas.SelectedItem as Nota;

            ID.Text = notaSelecionada.id.ToString();
            tituloNota.Text = notaSelecionada.tituloNota;
            txtNota.Text = notaSelecionada.txtNota;

            btnSave.Text = "Alterar";
        }

        //METODO PARA SALVAR UMA ANOTAÇÃO
        private void btnSave_Click(object sender, EventArgs e)
        {

            Nota nota = new Nota();

            nota.id = int.Parse(ID.Text);
            nota.tituloNota = tituloNota.Text;
            nota.txtNota = txtNota.Text;

            //ATERAR ANOTAÇÃO
            if (btnSave.Text == "Alterar")
            {
                try
                {
                    listaAnotacao[nota.id].tituloNota = nota.tituloNota;
                    listaAnotacao[nota.id].txtNota = nota.txtNota;

                    limparCampos();
                    preencherLista();
                }
                catch (Exception erro)
                {
                    Console.Write(erro);
                    MessageBox.Show("Erro na alteração do anotação!");
                }
            }
            else
            {
                if (tituloNota.Text != "" && txtNota.Text != "")
                {
                    try
                    {
                        listaAnotacao.Add(nota);

                        limparCampos();
                        preencherLista();

                    }
                    catch (Exception erro)
                    {
                        Console.Write(erro);
                        MessageBox.Show("Anotação não salva!");
                    }
                }
                else
                {
                    MessageBox.Show("Insira alguma nota!");
                }

            }

        }

        //PREENCHIMENTO DA LISTA
        private void preencherLista()
        {
            lstNotas.Items.Clear();
            foreach (Nota i in listaAnotacao)
            {
                lstNotas.Items.Add(i);
            }
        }

        //METODO PARA EXCLUIR UMA ANOTAÇÃO
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Nota nota = lstNotas.SelectedItem as Nota;

            try
            {
                listaAnotacao.RemoveAt(nota.id);

                limparCampos();
                preencherLista();
            }
            catch (Exception erro)
            {
                Console.Write(erro);
                MessageBox.Show("Erro na esclusão da anotação!");
            }

        }

        //METODO PARA LIMPAR CAMPOS
        private void limparCampos()
        {
            ID.Text = listaAnotacao.Count.ToString();
            tituloNota.Text = "";
            txtNota.Text = "";

            btnSave.Text = "Salvar";
        }

        //BOTAO
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ID.Text = listaAnotacao.Count.ToString();
            tituloNota.Text = "";
            txtNota.Text = "";

            btnSave.Text = "Salvar";

        }
       
    }
}
