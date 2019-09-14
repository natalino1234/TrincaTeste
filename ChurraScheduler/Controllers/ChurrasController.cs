using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using BancoDeDados.Impl;
using System.Configuration;

namespace ChurraScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrasController : ControllerBase
    {
        // POST api/Churras/Create
        [HttpPost]
        [Route("Create")]
        public JsonResult CreateChurras(
            int id_usuario, string authToken,
            string nome, string observacoes, string data, 
            string valorParticipante, string bebidaIncluida)
        {

            Usuario usuario = new Usuario(id_usuario, "", "", "", authToken);

            Churras churras = new Churras(
                nome, 
                observacoes, 
                Convert.ToDateTime(data), 
                Convert.ToDouble(valorParticipante), 
                Convert.ToBoolean(bebidaIncluida)
            );

            JsonResult j;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string local = appSettings["DatabasePath"] ?? "Not Found";
                ChurrasDAO dao = new ChurrasDAO(local);

                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    try
                    {
                        List<Churras> churs = dao.FindAll_Custom("" +
                            "Select " +
                            "   * " +
                            "from " +
                            "   churras " +
                            "where " +
                            "   nome = \"" + churras.Nome + "\" " +
                            "   and id_usuario = " + usuario.Id + ";");
                        if (churs.Count == 0)
                        {
                            dao.Insert(churras);

                            churs = dao.FindAll_Custom("" +
                                "Select " +
                                "   * " +
                                "from " +
                                "   churras " +
                                "where " +
                                "   nome = \"" + churras.Nome + "\" " +
                                "   and id_usuario = " + usuario.Id + ";");
                            churras = churs[0];
                            j = new JsonResult(new object[] { true, churras });
                        }
                        else
                        {
                            dao.Close();
                            j = new JsonResult(new object[] { false, "Você já possui um churrasco marcado com esse nome, tente outro." });
                        }
                    }
                    finally
                    {
                        dao.Close();
                    }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador." });
            }
            return j;
        }

        // POST api/Churras/Cancel
        [HttpPost]
        [Route("Cancel")]
        public ActionResult<IEnumerable<string>> CancelChurras(string authToken, int id)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/Churras/List
        [HttpPost]
        [Route("List")]
        public ActionResult<IEnumerable<string>> ListChurras(int id_usuario, string authToken)
        {

            Usuario usuario = new Usuario(id_usuario, "", "", "", authToken);

            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if(daouser.FindAll_Custom("Select * from usuario where authtoken = \""+usuario.AuthToken+"\" and login = \"" + usuario.Login + "\"").Count > 0) { 
                    ChurrasDAO dao = new ChurrasDAO(local);
                    try
                    {
                        List<Churras> churras = dao.FindAll_Custom("Select c.* from churras c, usuario u where c.id_usuario = u.id and u.authtoken = "+usuario.Id);
                        dao.Close();
                        j = new JsonResult(new object[] { true, churras });
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/Get
        [HttpPost]
        [Route("Get")]
        public ActionResult<IEnumerable<string>> EditChurras(int id_usuario, string authToken, int id)
        {
            Usuario usuario = new Usuario(id_usuario,"","","",authToken);

            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasDAO dao = new ChurrasDAO(local);
                    try
                    {
                        List<Churras> churras = dao.FindAll_Custom("Select * from churras where id_usuario = " + usuario.Id+" and id = "+id);
                        dao.Close();
                        j = new JsonResult(new object[] { true, churras });
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/AddParticipante
        [HttpPost]
        [Route("AdicionarParticipante")]
        public ActionResult<IEnumerable<string>> AddParticipanteChurras(string authToken, int id_churras, string nome)
        {

            Usuario usuario = new Usuario("", "", "", authToken);
            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasParticipanteDAO dao = new ChurrasParticipanteDAO(local);
                    try
                    {
                        ChurrasParticipante participante = new ChurrasParticipante(id_churras, nome, false);
                        dao.Insert(participante);

                        j = new JsonResult(new object[] { true,  dao.FindAll_Custom("Select * from churrasparticipante where id_churras = "+id_churras)});

                        dao.Close();
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/AddParticipante
        [HttpPost]
        [Route("RemoverParticipante")]
        public ActionResult<IEnumerable<string>> RemParticipanteChurras(string authToken, int id_participante, int id_churras)
        {

            Usuario usuario = new Usuario("", "", "", authToken);
            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasParticipanteDAO dao = new ChurrasParticipanteDAO(local);
                    try
                    {
                        ChurrasParticipante participante = new ChurrasParticipante(id_participante ,id_churras, "", false);
                        dao.Delete(participante);

                        j = new JsonResult(new object[] { true, dao.FindAll_Custom("Select * from churrasparticipante where id_churras = " + id_churras) });

                        dao.Close();
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

        // POST api/Churras/AddParticipante
        [HttpPost]
        [Route("ParticipantePagou")]
        public ActionResult<IEnumerable<string>> ParticipantePagouChurras(string authToken, int id_churras, int id_participante)
        {
            Usuario usuario = new Usuario("","","",authToken);

            JsonResult j;

            var appSettings = ConfigurationManager.AppSettings;
            string local = appSettings["DatabasePath"] ?? "Not Found";
            try
            {
                UsuarioDAO daouser = new UsuarioDAO(local);
                if (daouser.FindAll_Custom("Select * from usuario where authtoken = \"" + usuario.AuthToken + "\" and login = \"" + usuario.Login + "\"").Count > 0)
                {
                    ChurrasParticipanteDAO dao = new ChurrasParticipanteDAO(local);
                    try
                    {
                        dao.pagar(id_participante);

                        j = new JsonResult(new object[] { true, dao.FindAll_Custom("Select * from churrasparticipante where id_churras = " + id_churras) });

                        dao.Close();
                    }
                    finally { dao.Close(); }
                }
                else
                {
                    j = new JsonResult(new object[] { false, "Você não tem permissão para acessar essas informações." });
                }
            }
            catch (Exception e)
            {
                j = new JsonResult(new object[] { false, "Houve uma falha ao executar, contate o administrador.", local, e.StackTrace });
            }
            return j;
        }

    }
}
