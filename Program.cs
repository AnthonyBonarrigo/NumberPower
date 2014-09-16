using System;

namespace Assignment_01
{
    class NumberPowers
    {
        static void Main(string[] args)
        {
            double[] numbers;
            double[] userInputs;
            try
            {
                getInput(out userInputs);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("One or more input issues. Please try again");
                getInput(out userInputs);
            }
            calculatePowers(out numbers, userInputs);
            displayResults(numbers, userInputs);

        }

        static void getInput(out double[] userInputs)
        {
            userInputs = new double[3];
            double number;
            double powerMin;
            double powerMax;

            Console.WriteLine("Enter a double, min power, and max power separated by spaces:  ");
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            number = Convert.ToDouble(input[0]); 
            powerMin = Convert.ToDouble(input[1]); 
            powerMax = Convert.ToDouble(input[2]);

            if (number < 0.0)
                throw new ArgumentOutOfRangeException();
            else
                userInputs[0] = number;
            if (powerMin < 0.0)
                throw new ArgumentOutOfRangeException();
            else
                userInputs[1] = powerMin;
            if (powerMax == powerMin || powerMax < 0.0)
                throw new ArgumentOutOfRangeException();
            else
                userInputs[2] = powerMax;
        }

        static void calculatePowers(out double[] numbers, double[] inputs)
        {
            double number = inputs[0];
            double minPower = inputs[1];
            double maxPower = inputs[2];
            double currentPower = minPower;
            int powerDif = Convert.ToInt32(maxPower - minPower); //trying to make array only as big as it needs to be

            numbers = new double[powerDif * 2]; 

            int index = 0; //index for array
            
            while (currentPower <= maxPower)
            {
                try
                {
                    numbers[index] = Math.Pow(number, currentPower);
                }
                catch(IndexOutOfRangeException e)
                { Console.WriteLine("Something happened. Try again"); }
                
                index++;
                currentPower += 1;  
            }
            try
            {
                numbers[index] = Math.Pow(number, maxPower);
            }
            catch (IndexOutOfRangeException e)
            { Console.WriteLine("Something happened. Try again"); }

        }

        static void displayResults(double[] numbers, double[] inputs)
        {
            double power = inputs[1];
            foreach (double d in numbers)
            {
                if (d == 0)
                    continue;
                if(power < inputs[2])
                {
                    Console.WriteLine("Power: " + power);
                    Console.WriteLine("Calculated number: " + d);
                    power += 1;
                    continue;
                }

                if(power > inputs[2])
                {
                    power = inputs[2];
                    Console.WriteLine("Power: " + power);
                    Console.WriteLine("Calculated number: " + d);
                }

            }
        }
    }
}