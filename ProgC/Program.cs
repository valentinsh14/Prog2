// In Program.cs

using System.Diagnostics; // Required for Stopwatch

// --- Aufgabe 2 ---
Console.WriteLine("\n--- Aufgabe 2: Distribution Counting (Positive Numbers) ---");
int[] positiveNumbers = { 5, 2, 9, 5, 2, 8, 1, 9, 3, 5 };
Console.WriteLine("Original Array: " + string.Join(", ", positiveNumbers));
int[] sortedPositive = DistributionCounting(positiveNumbers);
Console.WriteLine("Sorted Array:   " + string.Join(", ", sortedPositive));

// --- Aufgabe 1 ---
Console.WriteLine("--- Aufgabe 1: Sorting Algorithms ---");

int[] sizes = { 10_000, 20_000, 50_000, 100_000 };
Random random = new Random();

foreach (int size in sizes)
{
    // Create a large array with random double values
    double[] array = new double[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = random.NextDouble() * 1000; // Random doubles between 0 and 1000
    }

    // Clone the array for each sort, so we don't sort an already sorted array
    double[] arrayForBubble = (double[])array.Clone();
    double[] arrayForSelection = (double[])array.Clone();
    double[] arrayForInsertion = (double[])array.Clone();

    Console.WriteLine($"\n--- Testing with {size} elements ---");
    
    // Measure Bubblesort
    MeasureSort("Bubblesort", BubbleSort, arrayForBubble);
    
    // Measure Selection Sort
    MeasureSort("Selection Sort", SelectionSort, arrayForSelection);
    
    // Measure Insertion Sort
    MeasureSort("Insertion Sort", InsertionSort, arrayForInsertion);
}


// Helper function to measure and print the time
void MeasureSort(string name, Action<double[]> sortMethod, double[] array)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    sortMethod(array);
    stopwatch.Stop();
    bool sortedCorrectly = IsSorted(array);
    
    Console.WriteLine($"{name} took: {stopwatch.ElapsedMilliseconds} ms, Is sorted: {sortedCorrectly}");
}
//Helper to see if sorted right
bool IsSorted(double[] arr)
{
    // Loop up to the second-to-last element
    for (int i = 0; i < arr.Length - 1; i++)
    {
        if (arr[i] > arr[i + 1]) return false;
    }

    // If the loop completes, it means no element was out of order.
    return true;
}

void BubbleSort(double[] arr)
{
    int n = arr.Length; // Get the total number of elements

    // The outer loop. This controls the number of passes.
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - 1 - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                double temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

void SelectionSort(double[] arr)
{
    int n = arr.Length;

    // The outer loop moves the boundary of the sorted subarray.
    for (int i = 0; i < n - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < n; j++)
        {
            if (arr[j] < arr[minIndex])
            {
                minIndex = j;
            }
        }
        
        double temp = arr[minIndex];
        arr[minIndex] = arr[i];
        arr[i] = temp;
    }
}

void InsertionSort(double[] arr)
{
    int n = arr.Length;

    for (int i = 1; i < n; i++)
    {

        double key = arr[i];

        int j = i - 1;
        
        
        while (j >= 0 && arr[j] > key)
        {
            // Shift the larger element to the right
            arr[j + 1] = arr[j];
            j = j - 1; // Move to the previous element
        }

        arr[j + 1] = key;
    }
}


// --- Aufgabe 2 & 3 ---

// You can add your functions for the other tasks here, for example:

int[] DistributionCounting(int[] arr)
{
    // Handle empty or null arrays
    if (arr == null || arr.Length == 0)
    {
        return new int[0];
    }
    
    // Step 1: Find the maximum value
    int maxVal = 0; // 1. Start by assuming 0 is the max (safe because numbers are positive)

// 2. Loop through every single 'number' in the 'arr' array
    foreach (int number in arr) 
    {
        // 3. Check if the current number is greater than the max we've found so far
        if (number > maxVal)
        {
            // 4. If it is, we have a new maximum! Update maxVal.
            maxVal = number; 
        }
    }

    int[] count = new int[maxVal + 1];
    foreach (int number in arr)
    {
        // For each 'number' from the input array, we use it as an index
        // into our 'count' array and increment the value.
        // This is the "counting" part.
        count[number]++;
    }

    // Step 4: Rebuild the sorted array
    int[] sortedArr = new int[arr.Length];
    int currentPosition = 0; // This is our "cursor" for the sortedArr

// Loop through the 'count' array. The index 'i' represents the number to place.
    for (int i = 0; i < count.Length; i++)
    {
        // 'count[i]' tells us how many times the number 'i' appeared.
        // We loop that many times.
        for (int j = 0; j < count[i]; j++)
        {
            // Place the number 'i' into the sorted array
            sortedArr[currentPosition] = i;

            // And move our cursor to the next empty spot
            currentPosition++;
        }
    }

    return sortedArr;
}

int[] DistributionCountingWithNegatives(int[] arr)
{
    // TODO: Implement Distribution Counting for positive and negative numbers
    return arr;
}