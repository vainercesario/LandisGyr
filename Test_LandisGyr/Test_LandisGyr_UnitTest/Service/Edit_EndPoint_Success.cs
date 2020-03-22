using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test_LandisGyr._3_Domain.Interfaces.DAO;
using Test_LandisGyr._3_Domain.Model;
using Test_LandisGyr._3_Domain.Service;
using Test_LandisGyr._4_Data;

namespace Test_LandisGyr_UnitTest.Service
{
    [TestClass]
    public class Edit_EndPoint_Success
    {
        private EndPointService _endPointService;
        private readonly EndPointDAO _endPointDAO = new EndPointDAO();
        private readonly Mock<IEndPointDAO> _mockRepo = new Mock<IEndPointDAO>();

        
        [TestMethod]
        public void Edit_Success()
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

            var endPointFor = new EndPoint
            {
                SerialNumber = "1",
                MeterModelId = EnumMeterModelId.NSX1P2W,
                MeterNumber = 1,
                MeterFirmwareVersion = "A91200-1",
                SwitchState = EnumSwitchState.Armed
            };

            _endPointDAO.Insert(endPoint1);
            _endPointDAO.Insert(endPoint2);
            _endPointService = new EndPointService(_endPointDAO);

            _mockRepo.Setup(x => x.Edit(endPoint1, endPointFor)).Returns(true);

            //Act
            var esperado = _mockRepo.Object.Edit(endPoint1, endPointFor);

            var realizado = _endPointService.Edit(endPoint1, endPointFor);

            //Assert
            Assert.AreEqual(esperado, realizado);

        }
    }
}
