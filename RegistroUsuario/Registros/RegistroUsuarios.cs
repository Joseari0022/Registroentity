﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;

namespace SistemaGonzalez.Registros
{
    public partial class RegistroUsuarios : Form
    {
        public RegistroUsuarios()
        {
            InitializeComponent();
        }

        Utilidades u = new Utilidades();
        private void Idbutton_Click(object sender, EventArgs e)
        {
            LlenarUsuario(UsuarioBll.Buscar(u.String(IdtextBox.Text)));
        }

        private void LlenarUsuario(Usuarios usuario)
        {
            IdtextBox.Text = usuario.Id.ToString();
            NombretextBox.Text = usuario.Nombres;
            ContrasenatextBox.Text = usuario.Contrasena;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdtextBox.Clear();
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            ConfirmarContrasenatextBox.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            LlenarClase(usuario);
            if (ValidTextB() && ValidarExistente(NombretextBox.Text))
            {
                UsuarioBll.Guardar(usuario);
                MessageBox.Show("Guardado con exito!!!!");
            }
        }

        public void LlenarClase(Usuarios u)
        {
            u.Nombres = NombretextBox.Text;
            u.Contrasena = ContrasenatextBox.Text;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            UsuarioBll.Eliminar(u.String(IdtextBox.Text));
            MessageBox.Show("Usuario Eliminado");
        }

        public bool ValidTextB()
        {
            if (string.IsNullOrEmpty(NombretextBox.Text) && string.IsNullOrEmpty(ContrasenatextBox.Text) && string.IsNullOrEmpty(ConfirmarContrasenatextBox.Text))
            {
                NombreerrorProvider.SetError(NombretextBox, "Ingrese el nombre");
                ContrasenaerrorProvider.SetError(ContrasenatextBox, "Ingrese contraseña");
                ConfirmarContrasenaerrorProvider.SetError(ConfirmarContrasenatextBox, "La contraseña no coincide");
                MessageBox.Show("Llenar todos los campos");
            }
            if (string.IsNullOrEmpty(NombretextBox.Text))
            {
                NombreerrorProvider.SetError(NombretextBox, "Ingrese el nombre");
                return false;
            }
            if (string.IsNullOrEmpty(ContrasenatextBox.Text))
            {
                NombreerrorProvider.Clear();
                ContrasenaerrorProvider.SetError(ContrasenatextBox, "Ingrese contraseña");
                return false;
            }
            if (string.IsNullOrEmpty(ConfirmarContrasenatextBox.Text))
            {
                NombreerrorProvider.Clear();
                ContrasenaerrorProvider.Clear();
                ConfirmarContrasenaerrorProvider.SetError(ConfirmarContrasenatextBox, "Confirmar contraseña ");
                return false;
            }
            if (ContrasenatextBox.Text != ConfirmarContrasenatextBox.Text)
            {
                NombreerrorProvider.Clear();
                ContrasenaerrorProvider.Clear();
                ConfirmarContrasenaerrorProvider.Clear();
                ConfirmarContrasenaerrorProvider.SetError(ConfirmarContrasenatextBox, "La contraseña no coincide");
                return false;
            }
            return true;
        }

        private bool ValidarExistente(string aux)
        {
            if (UsuarioBll.GetListaNombreUsuario(aux).Count() > 0)
            {
                MessageBox.Show("Este usuario existe....");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
