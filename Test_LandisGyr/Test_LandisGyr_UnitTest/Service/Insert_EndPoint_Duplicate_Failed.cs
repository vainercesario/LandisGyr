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
    public class Insert_EndPoint_Duplicate_Failed
    {
        
        private EndPointService _endPointService;
        private readonly EndPointDAO _endPointDAO;
        private readonly Mock<IEndPointDAO> _mockRepo = new Mock<IEndPointDAO>();

        public Insert_EndPoint_Duplicate_Failed()
        {
            _endPointDAO = new EndPointDAO();
        }

        [TestMethod]
        public void Not_Insert_More_EndPoint()
        {
            //Arrange
            var endPoint1 = new EndPoint
            {
                SerialNumber = "1",
                MeterModelId = EnumMeterModelId.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "A91200-1",
                SwitchState = EnumSwitchState.Disconnected
            };
            var endPoint2 = new EndPoint
            {
                SerialNumber = "1",
                MeterModelId = EnumMeterModelId.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "A91200-1",
                SwitchState = EnumSwitchState.Disconnected
            };

            _endPointDAO.Insert(endPoint1);
            _endPointService = new EndPointService(_endPointDAO);

            _mockRepo.Setup(x => x.Insert(endPoint1)).Returns(false);

            //Act
            var esperado = _mockRepo.Object.Insert(endPoint1);
            var realizado = _endPointService.Insert(endPoint2);

            //Assert
            Assert.AreEqual(realizado, esperado);
        }
    }
}
