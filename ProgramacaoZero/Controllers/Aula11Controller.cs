using Microsoft.AspNetCore.Mvc;
using ProgramacaoZero.Models;
using System.Reflection.Metadata;

namespace ProgramacaoZero.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [HttpGet]
        [Route("obterVeiculo")]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Branco";
            meuVeiculo.Marca = "Hyundai";
            meuVeiculo.Modelo = "HB20";
            meuVeiculo.Placa = "QWV-5D67";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Placa = "DRT-2352";
            meuCarro.Cor = "Vermelho";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Dafra";
            minhaMoto.Modelo = "Riva";
            minhaMoto.Placa = "FYX-4I67";
            minhaMoto.Cor = "Branco";

            minhaMoto.Acelerar();

            return minhaMoto;
        }
    }
}
