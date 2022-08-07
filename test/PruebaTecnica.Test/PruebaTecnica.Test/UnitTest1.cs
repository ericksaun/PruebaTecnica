using Application.Module;
using Domain.PruebaTecnica.Interfaces;
using Domain.PruebaTecnica.Models;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;

namespace PruebaTecnica.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestGetClientes()
        {
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<IClientRepository> mockClientRepository = new Mock<IClientRepository>();
            List<Clientes> _clientes = new();

           Clientes cliente= new Clientes()
            {
                cl_contraseña = "1234",
                Id = 1,
                cl_estado = true,
                pr_direccion = "Conocoto",
                pr_edad = 32,
                pr_genero = "Masculino",
                pr_identificacion = "1722198049",
                pr_nombre = "Erick Salinas",
                pr_telefono = "0987542142"


            };
            _clientes.Add(cliente);

            mockClientRepository.Setup(x => x.GetAll()).Returns(_clientes);
            mockUOW.Setup(x => x.clientes).Returns(mockClientRepository.Object);
            ClientServices clientServices = new ClientServices(mockUOW.Object);
            IEnumerable<Clientes> clientes = clientServices.GetClientes();
            Assert.IsNotNull(clientes);
        }

        [TestMethod]
        public void TestGetMovementsbyUserAndRangeOfDate()
        {
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<IMovementsRepository> mockMovementsRepository = new Mock<IMovementsRepository>();
            Mock<IConfiguration> mockConfiguration = new Mock<IConfiguration>();
            mockUOW.Setup(x => x.movimientos).Returns(mockMovementsRepository.Object);
            mockConfiguration.Setup(x => x.GetSection("AppSettings:CupoDiario").Value).Returns("1000");
            int IDUser = 1;
            DateTime Fecha_inicial = Convert.ToDateTime("2022-08-07");
            DateTime Fecha_final = Convert.ToDateTime("2022-08-07");
            string MovimientosJson = "[{\"id\": 39,\"mo_fecha\": \"2022-08-07T02:06:03.2271936\",\"mo_tipo_movimiento\": \"Credito\",\"mo_valor\": 600,\"mo_saldo\": 700,\"cuenta\": {  \"id\": 9,  \"cu_numero_cuenta\": 225487,  \"cu_tipo_cuenta\": \"Corriente\",  \"cu_saldo_inicial\": 100,  \"cu_estado\": true,  \"cliente\": {\"id\": 13,\"cl_contraseña\": \"5678\",\"cl_estado\": true,\"pr_nombre\": \"Marianela Montalvo\",\"pr_genero\": \"Femenino\",\"pr_edad\": 45,\"pr_direccion\": \"Amazonas y NNUU\",\"pr_identificacion\": \"1616161616\",\"pr_telefono\": \"097548965\"  }}  },  {\"id\": 41,\"mo_fecha\": \"2022-08-07T02:08:40.2043542\",\"mo_tipo_movimiento\": \"Debito\",\"mo_valor\": -540,\"mo_saldo\": 0,\"cuenta\": {  \"id\": 10,  \"cu_numero_cuenta\": 496825,  \"cu_tipo_cuenta\": \"Ahorros\",  \"cu_saldo_inicial\": 540,  \"cu_estado\": true,  \"cliente\": {\"id\": 13,\"cl_contraseña\": \"5678\",\"cl_estado\": true,\"pr_nombre\": \"Marianela Montalvo\",\"pr_genero\": \"Femenino\",\"pr_edad\": 45,\"pr_direccion\": \"Amazonas y NNUU\",\"pr_identificacion\": \"1616161616\",\"pr_telefono\": \"097548965\"  }}  }]";
          List<Movimientos> movimientos =new();


            movimientos= JsonConvert.DeserializeObject<List<Movimientos>>(MovimientosJson);
            mockMovementsRepository.Setup(x => x.GetMovementsbyUserAndRangeOfDate(IDUser, Fecha_inicial, Fecha_final)).Returns(movimientos);


            MovementsServices movementsServices = new MovementsServices(mockUOW.Object, mockConfiguration.Object);
           IEnumerable<Movimientos> Reporte=movementsServices.GetMovementsbyUserAndRangeOfDate(IDUser, Fecha_inicial, Fecha_final);
          
            Assert.IsNotNull(Reporte);
        }
    }
}