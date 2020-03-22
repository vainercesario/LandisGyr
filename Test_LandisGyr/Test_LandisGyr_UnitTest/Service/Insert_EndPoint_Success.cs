using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Interfaces.Service;
using Test_LandisGyr._3_Domain.Model;
using Test_LandisGyr._3_Domain.Service;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr_UnitTest.Service
{
    [TestClass]
    public class Insert_EndPoint_Success
    {
        private readonly EndPointService _sutService;
        
        private readonly Mock<IEndPointDAO> _mockRepoDao = new Mock<IEndPointDAO>();

        List<EndPoint> data = new List<EndPoint>();


        public Insert_EndPoint_Success()
        {
            _sutService = new EndPointService(_mockRepoDao.Object);
        }

        [TestMethod]
        public void Insert_Successfully()
        {
            //Arrange
            var endPoint = new EndPoint
            {
                SerialNumber = "1AA1",
                MeterModelId = EnumMeterModelId.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "A91200-1",
                SwitchState = EnumSwitchState.Disconnected
            };

            var endPoint2 = new EndPoint
            {
                SerialNumber = "2BB2",
                MeterModelId = EnumMeterModelId.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "A91200-1",
                SwitchState = EnumSwitchState.Disconnected
            };
            
            _mockRepoDao.Setup(e => e.Insert(endPoint)).Returns(true);
            _mockRepoDao.Setup(e => e.Insert(endPoint2)).Returns(true);

            //Act
            var resultadoEsperado1 = _mockRepoDao.Object.Insert(endPoint);
            var resultadoEsperado2 = _mockRepoDao.Object.Insert(endPoint2);

            var realizado1 = _sutService.Insert(endPoint);
            var realizado2 = _sutService.Insert(endPoint2);

            //Assert
            Assert.IsTrue(realizado1 == resultadoEsperado1);
            Assert.IsTrue(realizado2 == resultadoEsperado2);

        }
    }
}
