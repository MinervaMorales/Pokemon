using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Pokemon.Common.Entities;
using Pokemon.Controllers;
using Pokemon.Services.Facade;
using Pokemon.Services.Mappers;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Tests.Presentation.Controllers
{
    [TestFixture]
    public class PokemonControllerTest
    {
        private PokemonesController _controller;
        private Pokemones _pokemon;
        private PokemonDto _dto;

        [SetUp]
        public void SetUp()
        {
            _controller = new PokemonesController();

            List<Poder> poderes = new List<Poder>();

            for (int i = 0; i < 5; i++)
            {
                Poder poder = new Poder(i + 1, "poder controller " + i);
                poderes.Add(poder);
            }

            _pokemon = new Pokemones("Controller 1", poderes, new Categoria(2, "categoria 2"), 600, "observaciones pokemon");

            _dto = PokemonMapper.MapEntityToDto(_pokemon);

        }


        [Test]
        public void PostTestOk()
        {
            Assert.IsInstanceOf<OkResult>(_controller.Post(_dto));

        }

        [Test]
        public void PostTestBadRequest()
        {
           Assert.IsInstanceOf<BadRequestResult>(_controller.Post(null));
        }

        [Test]
        public void PutTestOk()
        {
            _dto.Nombre = "Controller Put Prueba";

            Assert.IsInstanceOf<OkResult>(_controller.Put(_dto));
        }

        [Test]
        public void PutTestBadRequest()
        {
            Assert.IsInstanceOf<BadRequestResult>(_controller.Put(null));
        }

        [Test]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_controller.GetById(0));
        }

        [Test]
        public void GetAllTest()
        {
            Assert.IsNotNull(_controller.GetAll());
        }
    }

}