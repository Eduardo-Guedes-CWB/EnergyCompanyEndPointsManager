using Business.Helpers;
using System;
using UI.Interfaces;

namespace UI.Controllers
{
    public class OrchestratorApplication : IOrchestratorApplication
    {
        private readonly IInitialOptions _initialOptions;
        private readonly ICreateEndpoint _createEndpoint;
        private readonly IActionConfirmation _actionConfirmation;
        private readonly IReadEndpoint _readEndpoint;
        private readonly IIndexEndpoint _indexEndpoint;
        private readonly IDeleteEndpoint _deleteEndpoint;
        private readonly IUpdateEndpoint _updateEndpoint;
        public OrchestratorApplication(IInitialOptions initialOptions, ICreateEndpoint createEndpoint,
                                       IActionConfirmation actionConfirmation, IReadEndpoint readEndpoint,
                                       IIndexEndpoint indexEndpoint, IDeleteEndpoint deleteEndpoint,
                                       IUpdateEndpoint updateEndpoint)
        {
            _initialOptions = initialOptions;
            _createEndpoint = createEndpoint;
            _actionConfirmation = actionConfirmation;
            _readEndpoint = readEndpoint;
            _indexEndpoint = indexEndpoint;
            _deleteEndpoint = deleteEndpoint;
            _updateEndpoint = updateEndpoint;
        }

        public void Initialize()
        {
            int optionSelected = _initialOptions.UserInteraction();
            string resultText;
            switch (optionSelected)
            {
                #region Create
                case 1:
                    Console.WriteLine();
                    resultText = _createEndpoint.Create();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(resultText);
                    Console.WriteLine();
                    ExecuteAnotherOpration();                    
                    break;
                #endregion
                #region Index
                case 4:
                    _indexEndpoint.Index();
                    ExecuteAnotherOpration();
                    break;
                #endregion
                #region Edit
                case 2:
                    Console.WriteLine();
                    resultText = _updateEndpoint.Update();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(resultText);
                    Console.WriteLine();
                    ExecuteAnotherOpration();
                    break;
                #endregion
                #region Delete
                case 3:
                    Console.WriteLine();
                    resultText = _deleteEndpoint.Delete();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(resultText);
                    Console.WriteLine();
                    ExecuteAnotherOpration();
                    break;
                #endregion
                #region Read
                case 5:
                    _readEndpoint.Read();
                    ExecuteAnotherOpration();
                    break;
                #endregion
                #region Close App
                default:
                    Console.Clear();
                    Console.WriteLine(SystemName.Name.ToUpper());
                    Console.WriteLine();
                    Console.WriteLine("Do you want to close the application? (Y / N)");
                    if (_actionConfirmation.GetConfirmation())
                        Environment.Exit(0);
                    else
                        Initialize();
                    break;
                    #endregion
            }
        }

        private void ExecuteAnotherOpration()
        {
            Console.WriteLine("Do you want to execute another operation? (Y / N)");
            if (_actionConfirmation.GetConfirmation())
                Initialize();
            else
                Environment.Exit(0);
        }
    }
}
