namespace OOP_5lab_Interfaces
{
    internal class Program
    {
        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            // I'm not sure how to create constant factor "2" in more elegant way,
            // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===\n");
        }
        public static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a^2-b^2)/(a+b) = a-b with a = " + a + ", b = " + b + " ===");

            // --- ЛІВА ЧАСТИНА: a - b (Перевіряє Subtract) ---
            T leftSide = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("a - b = " + leftSide); // Вивід Лівої Частини

            Console.WriteLine(" = = = ");

            // --- ПРАВА ЧАСТИНА: (a^2 - b^2) / (a + b) (Перевіряє Multiply, Subtract, Divide) ---

            T aSquared = a.Multiply(a);
            Console.WriteLine("a^2 = " + aSquared);

            T bSquared = b.Multiply(b);
            Console.WriteLine("b^2 = " + bSquared);

            T numerator = aSquared.Subtract(bSquared);
            Console.WriteLine("a^2 - b^2 = " + numerator);

            T denominator = a.Add(b);
            Console.WriteLine("a + b = " + denominator);

            T rightSide;

            // Обчислення Правої Частини з обробкою винятків
            try
            {
                rightSide = numerator.Divide(denominator);
                Console.WriteLine("(a^2 - b^2) / (a + b) = " + rightSide); // Вивід Правої Частини
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ділення: ПОПЕРЕДЖЕННЯ. Виняток 'Ділення на нуль' коректно спрацював.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ділення: ПОМИЛКА. Виникла несподівана помилка: " + ex.Message);
            }

            Console.WriteLine("=== Finishing testing (a^2-b^2)/(a+b) = a-b with a = " + a + ", b = " + b + " ===\n");
        }
        public static void TestIComparableImplementation<T>(T[] data) where T : IComparable<T>
        {
            Console.WriteLine("\n=== Starting testing IComparable implementation for type " + typeof(T).Name + " ===");

            // Виводимо початковий масив
            Console.WriteLine("Початковий масив:");
            Console.WriteLine(string.Join(", ", data));

            // Виконуємо сортування, яке вимагає реалізації CompareTo
            try
            {
                Array.Sort(data);

                // Виводимо відсортований масив
                Console.WriteLine("Відсортований масив:");
                Console.WriteLine(string.Join(", ", data));

                // Ми не можемо знати правильний порядок, але можемо перевірити,
                // чи сортування не порушило порядок для сусідніх елементів.
                bool isSorted = true;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    // Якщо поточний елемент більший за наступний, сортування НЕ відбулося коректно
                    if (data[i].CompareTo(data[i + 1]) > 0)
                    {
                        isSorted = false;
                        break;
                    }
                }

                if (isSorted)
                {
                    Console.WriteLine("Статус: OK. Масив відсортовано коректно (a <= b).");
                }
                else
                {
                    Console.WriteLine("Статус: ПОМИЛКА. Масив відсортовано не коректно.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Статус: ПОМИЛКА. Виник виняток під час сортування: {ex.Message}");
            }

            Console.WriteLine("=== Finishing testing IComparable implementation ===\n");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            TestSquaresDifference(new MyFrac(5, 1), new MyFrac(-5, 1));
            TestSquaresDifference(new MyComplex(1, 1), new MyComplex(-1, -1));
            TestIComparableImplementation(new MyFrac[]
            {
                new MyFrac(1, 2),
                new MyFrac(4, 6),
                new MyFrac(1, 3),
                new MyFrac(2, 3)
            });
        }
    }
}
