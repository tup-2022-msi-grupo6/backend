using System;
using Xunit;
using WSVentas;
using WSVentas.Models;
using WSVentas.Controllers;
using WSVentas.Models.Request;
using WSVentas.Services;
using Moq;

namespace WSVentas.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void AddCliente_ShouldWork()
        {
            //Arrange
            var clienteController = new ClienteController();
            var cliente = new ClienteRequest { IdCliente = 3, Nombre = "Tomas testing" };

            //Act
            var result = clienteController.Add(cliente);

            //Assert
            var c = Assert.IsType<Cliente>(result);
            Assert.NotNull(cliente);
            Assert.Equal("Tomas testing", cliente.Nombre);
            Assert.Equal(3, cliente.IdCliente);
        }
    }
}
