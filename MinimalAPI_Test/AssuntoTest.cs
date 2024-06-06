using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Testing;
using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Test;
using System.Net;
using System.Net.Http.Json;

namespace Prime.UnitTests.Services
{
    public class AssuntoTest : WebApplicationFactory<Program>
    {
        [Test]
        public async Task Get_Assuntos_Return_All()
        {
            // monta
            await using var app = new MinimalAPI_Application();
            await Minimal_MockData.CreateAssuntos(app, true);
            var url = "/Assuntos";
            var client = app.CreateClient();

            // executa
            var result = await client.GetAsync(url);
            var assuntos = await client.GetFromJsonAsync<List<Assunto>>("/Assuntos");

            // verifica
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsNotNull(assuntos);
            Assert.IsTrue(assuntos.Count == 2);
        }
    }
}