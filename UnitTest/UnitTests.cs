using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Business.Controllers;
using Business.Interfaces;
using Moq;
using Business.Entities;

namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        private readonly CreateEndpointBusiness createEndpointBusiness = new CreateEndpointBusiness(new Mock<ICheckEndpoint>().Object);
        private readonly ReadEndpointBusiness readEndpointBusiness = new ReadEndpointBusiness();
        private readonly UpdateEndpointBusiness updateEndpointBusiness = new UpdateEndpointBusiness(new Mock<ICheckEndpoint>().Object);
        private readonly DeleteEndpointBusiness deleteEndpointBusiness = new DeleteEndpointBusiness(new Mock<ICheckEndpoint>().Object);
        

        [TestMethod]
        public void CreateValidTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "Teste1",
                MeterModelId = 16,
                MeterNumber = 12,
                MeterFirmwareVersion = "V1",
                SwitchState = 0
            };

            var result = createEndpointBusiness.Create(endpoint);
            Assert.IsTrue(result.Item1);

        }

        [TestMethod]
        public void CreateWithoutSerialNumberTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "",
                MeterModelId = 16,
                MeterNumber = 12,
                MeterFirmwareVersion = "V1",
                SwitchState = 0
            };

            var result = createEndpointBusiness.Create(endpoint);
            Assert.IsFalse(result.Item1);

        }

        [TestMethod]
        public void CreatetWithoutMeterFirmwareVersionTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "Teste",
                MeterModelId = 16,
                MeterNumber = 12,
                MeterFirmwareVersion = "",
                SwitchState = 0
            };

            var result = createEndpointBusiness.Create(endpoint);
            Assert.IsFalse(result.Item1);

        }

        [TestMethod]
        public void CreateInvalidMeterModelIdTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "Teste",
                MeterModelId = 10,
                MeterNumber = 12,
                MeterFirmwareVersion = "V1",
                SwitchState = 0
            };

            var result = createEndpointBusiness.Create(endpoint);
            Assert.IsFalse(result.Item1);

        }

        [TestMethod]
        public void CreateInvalidSwitchStateTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "Teste",
                MeterModelId = 16,
                MeterNumber = 12,
                MeterFirmwareVersion = "V1",
                SwitchState = 4
            };

            var result = createEndpointBusiness.Create(endpoint);
            Assert.IsFalse(result.Item1);

        }

        [TestMethod]
        public void CreateNullTest()
        {
            Endpoint endpoint = null;
            var result = createEndpointBusiness.Create(endpoint);
            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void ReadNullTest()
        {
            var result = readEndpointBusiness.Read(null);
            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void ReadNotFoundTestTest()
        {
            var result = readEndpointBusiness.Read("teste");
            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void UpdateNullTest()
        {
            Endpoint endpoint = null;
            var result = updateEndpointBusiness.Update(endpoint);
            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void UpdateNotFoundTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "Teste1",
                MeterModelId = 16,
                MeterNumber = 12,
                MeterFirmwareVersion = "V1",
                SwitchState = 0
            };

            var result = updateEndpointBusiness.Update(endpoint);
            Assert.IsFalse(result.Item1);

        }

        [TestMethod]
        public void DeleteNullTest()
        {
            Endpoint endpoint = null;
            var result = deleteEndpointBusiness.Delete(endpoint);
            Assert.IsFalse(result.Item1);
        }

        [TestMethod]
        public void DeleteNotFoundTest()
        {
            Endpoint endpoint = new Endpoint
            {
                EndpointSerialNumber = "Teste1",
                MeterModelId = 16,
                MeterNumber = 12,
                MeterFirmwareVersion = "V1",
                SwitchState = 0
            };

            var result = deleteEndpointBusiness.Delete(endpoint);
            Assert.IsFalse(result.Item1);

        }
    }
}
