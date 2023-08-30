using ProgramacaoZero.Common;
using ProgramacaoZero.Entities;
using ProgramacaoZero.Models;
using ProgramacaoZero.Repositorio;

namespace ProgramacaoZero.Services
{
    public class UsuarioService
    {
        private String _connectionString;

        public UsuarioService(string connectionString) 
        {
            _connectionString = connectionString;
        } 
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuário existe
                if (usuario.Senha == senha)
                {
                    //senha válida
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos.";
                }

            }
            else
            {
                //usuário não existe
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos.";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuário já existe
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema.";
            }
            else
            {
                //usuário não existe
                usuario = new Usuario();

                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = usuarioRepository.Inserir(usuario);

                if (affectedRows > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente.";

                }
            }

            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                //não existe
                result.sucesso = false;
                result.mensagem = "Usuário não existe para esse E-mail.";
            }
            else
            {
                //usuario existe
                var emailSander = new EmailSender();

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é " + usuario.Senha;

                var emailSender = new EmailSender();

                emailSander.Enviar(assunto, corpo, usuario.Email);
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
