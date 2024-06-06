using Microsoft.AspNetCore.Mvc.Testing;
using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Test;
using System.Net;
using System.Net.Http.Json;

namespace Prime.UnitTests.Services;

public class AssuntoTest : WebApplicationFactory<Program>
    {
        [Test]
        public async Task GET_Assuntos_Return_All()
        {
            await using var app = new MinimalAPI_Application();
            await Minimal_MockData.CreateAssuntos(app, true);
            var URL = "/Assuntos";
            var client = app.CreateClient();

            var result = await client.GetAsync(URL);
            var assuntos = await client.GetFromJsonAsync<List<Assunto>>("/Assuntos");

            Assert.Multiple(() =>
            {
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(assuntos, Is.Not.Null);
            });
            Assert.That(assuntos, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task POST_Cria_Novo_Assunto()
    {
        await using var app = new MinimalAPI_Application();
        await Minimal_MockData.CreateAssuntos(app, true);

        var assunto = new Assunto("Terror");
        var client = app.CreateClient();
        var response = await client.PostAsJsonAsync("/Assuntos", assunto);
        var assuntos = await client.GetFromJsonAsync<List<Assunto>>("/Assuntos");

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        Assert.That(assuntos, Has.Count.EqualTo(3));
    }

    [Test]
    public async Task DELETE_Exclui_Assunto_Existente()
    {
        await using var app = new MinimalAPI_Application();
        await Minimal_MockData.CreateAssuntos(app, true);

        var client = app.CreateClient();
        var URL = "/Assuntos/3FA85F64-5717-4562-B3FC-2C963F66AFA6";
        var response = await client.DeleteAsync(URL);
        var assuntos = await client.GetFromJsonAsync<List<Assunto>>("/Assuntos");

        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        Assert.That(assuntos, Is.Not.Null);
        Assert.That(assuntos, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task DELETE_Exclui_Assunto_Inexistente()
    {
        await using var app = new MinimalAPI_Application();
        await Minimal_MockData.CreateAssuntos(app, true);

        var client = app.CreateClient();
        var URL = "/Assuntos/3FA85F64-5717-4562-B3FC-2C963F66AFA6GIL";
        var response = await client.DeleteAsync(URL);

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Test]
    public async Task PUT_Atualiza_Assunto_Existente()
    {
        await using var app = new MinimalAPI_Application();
        await Minimal_MockData.CreateAssuntos(app, true);

        var client = app.CreateClient();
        var URL = "/Assuntos/3FA85F64-5717-4562-B3FC-2C963F66AFA6";

        var assunto = new Assunto("Drama");

        var response = await client.PutAsJsonAsync(URL, assunto);
        var assuntos = await client.GetFromJsonAsync<List<Assunto>>("/Assuntos");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
