using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ToHModels;
using ToHBL;
using ToHMVC.Controllers;
using ToHMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToHTests
{
    public class HeroControllerTest
    {
        [Fact]
        public void HeroControllerShouldReturnIndex()
        {
            //creating a stub iherobl but we're using moq the framework in moq, fake objects are called mock
            var mockRepo = new Mock<IHeroBL>();
            // this is just us defining what the stub would do/return if the method getheroes() is called
            //we're returning a static list of heroes
            mockRepo.Setup(x => x.GetHeroes())
                .Returns(new List<Hero>()
                {
                   new Hero
                    {
                        Id = 1,
                        HeroName = "Aquaperson",
                        HP = 1500,
                        ElementType = Element.Water,
                        SuperPower = new SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breate underwater, and swim really fast.",
                            Damage = 150
                        }
                    },
                   new Hero
                    {
                        Id = 1,
                        HeroName = "Batman",
                        HP = 100,
                        ElementType = (Element)2,
                        SuperPower = new SuperPower
                        {
                            Id = 2,
                            Name = "Rich",
                            Description = "He can buy you out. Also he knows the secrets of all the other justice league members",
                            Damage = 75
                        }
                    }

                });
            //I don't need to create a fake mapper because the real one doesn't affect the state
            //of my data, just it's type (it just casts stuff)
            var controller = new HeroController(mockRepo.Object, new Mapper());

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            //make sure the model that's being tied to that view is a list of viewmodels
            var model = Assert.IsAssignableFrom<IEnumerable<HeroIndexVM>>(viewResult.ViewData.Model);
            //want to make sure that we are getting 2 elements from the list (we are passing in 2 elements)
            Assert.Equal(2, model.Count());
        }
    }
}
