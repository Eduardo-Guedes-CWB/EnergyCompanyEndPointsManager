using Business.Entities;
using Business.Helpers;
using Business.Interfaces;
using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class CreateEndpoint : ICreateEndpoint
    {
        private readonly ICreateEndpointBusiness _createEndpointBusiness;
        private readonly IActionConfirmation _actionConfirmation;
        public CreateEndpoint(ICreateEndpointBusiness createEndpointBusiness, IActionConfirmation actionConfirmation)
        {
            _createEndpointBusiness = createEndpointBusiness;
            _actionConfirmation = actionConfirmation;
        }
        public string Create()
        {
            Endpoint endpoint = new Endpoint();
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("INSERT ENDPOINT");
            Console.WriteLine("Insert below the data to a new endpoint");
            Console.WriteLine();

            #region Serial Numer
            Console.Write("Enter serial number here: ");
            endpoint.EndpointSerialNumber = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(endpoint.EndpointSerialNumber))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid serial number");
                Console.Write("Enter serial number here: ");
                endpoint.EndpointSerialNumber = Console.ReadLine();
            }
            Console.WriteLine();
            #endregion

            #region Meter model id
            Console.WriteLine("Meter Model Id");
            Console.WriteLine("For NSX1P2W, enter 16");
            Console.WriteLine("For NSX1P3W, enter 17");
            Console.WriteLine("For NSX2P3W, enter 18");
            Console.WriteLine("For NSX3P4W, enter 19");
            Console.Write("Enter meter model id here: ");
            int meterModelId;
            int.TryParse(Console.ReadLine(), out meterModelId);
            while (meterModelId < 16 || meterModelId > 19)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid meter model id");
                Console.Write("Enter meter model id here: ");
                int.TryParse(Console.ReadLine(), out meterModelId);
            }
            endpoint.MeterModelId = meterModelId;
            Console.WriteLine();
            #endregion

            #region Meter number
            Console.Write("Enter meter number here: ");
            int meterNumber;
            bool meterNumerberOk = int.TryParse(Console.ReadLine(), out meterNumber);
            while (!meterNumerberOk)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid number");
                Console.Write("Enter meter number here: ");
                meterNumerberOk = int.TryParse(Console.ReadLine(), out meterNumber);
            }
            endpoint.MeterNumber = meterNumber;
            Console.WriteLine();
            #endregion

            #region Meter Firmware Version
            Console.Write("Enter meter firmware version here: ");
            endpoint.MeterFirmwareVersion = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(endpoint.MeterFirmwareVersion))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid meter firmware version");
                Console.Write("Enter meter firmware version here: ");
                endpoint.MeterFirmwareVersion = Console.ReadLine();
            }
            Console.WriteLine();
            #endregion

            #region Switch State
            Console.WriteLine("Switch State");
            Console.WriteLine("For Disconnected, enter 0");
            Console.WriteLine("For Connected, enter 1");
            Console.WriteLine("For Armed, enter 2");
            Console.Write("Enter switch state here: ");
            int switchState;
            bool switchStateOk = int.TryParse(Console.ReadLine(), out switchState);
            while (!switchStateOk || (switchState < 0 || switchState > 2))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid value, insert a valid switch state");
                Console.Write("Enter switch state here: ");
                switchStateOk = int.TryParse(Console.ReadLine(), out switchState);
            }
            endpoint.SwitchState = switchState;
            Console.WriteLine();
            #endregion

            #region Confirmation operation
            Console.Clear();
            Console.WriteLine(SystemName.Name.ToUpper());
            Console.WriteLine();
            Console.WriteLine("You completed the insert of basic data.");
            Console.WriteLine();
            Console.WriteLine("Follow below the data inputted:");
            Console.WriteLine();
            Console.WriteLine($"Serial Number: {endpoint.EndpointSerialNumber};");
            Console.WriteLine($"Meter Model Id: {endpoint.MeterModelId} ({(ModelIdEnum.ModelId)endpoint.MeterModelId});");
            Console.WriteLine($"Meter Number: {endpoint.MeterNumber};");
            Console.WriteLine($"Meter Firmware Version: {endpoint.MeterFirmwareVersion};");
            Console.WriteLine($"Switch State: {endpoint.SwitchState} ({(SwitchStateEnum.SwitchState)endpoint.SwitchState}).");
            Console.WriteLine();
            Console.WriteLine("Do you want to insert this endpoint? (Y / N)");
            if (_actionConfirmation.GetConfirmation())
            {
               return _createEndpointBusiness.Create(endpoint).Item2;
            }
            else
            {
                return "Operation aborted";
            }
            #endregion
        }
    }
}
