using System;
using System.Device.Gpio;

namespace RPiButtons
{
    class IoPin
    {

        private GpioController _cntrl;
        private int _pin;

        public IoPin(int pin)
        {
            _cntrl = new GpioController(PinNumberingScheme.Board);
            _pin = pin;
            _cntrl.OpenPin(pin, PinMode.Input);
        }

        ~IoPin()
        {
            _cntrl.ClosePin(_pin);
        }

        public bool ReadPin()
        {
            if (_cntrl.Read(_pin) == PinValue.High)
            {
                return true;
            }

            return false;
        }
    }
}
