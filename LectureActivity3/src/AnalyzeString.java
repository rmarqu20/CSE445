import java.util.*;

public class AnalyzeString 
{
	public static void main(String[] args) 
	{
		Scanner scan = new Scanner(System.in);
		System.out.print("Please enter a string: ");  
		String str = scan.nextLine();
		// Create an instance of DigitCountThread
		DigitCountThread DigitCountThread = new DigitCountThread(str);
		
		// Create an instance of upperCountThread
		upperCountThread upperCountThread = new upperCountThread(str);
		
		// Create an instance of isPalindrome 
		isPalindromeThread isPalindromeThread = new isPalindromeThread(str);
		
		// Start DigitCountThread instance created above
		DigitCountThread.start();
		
		// Start upperCountThread instance created above
		upperCountThread.start();
		
		// Start isPalindrome instance created above
		isPalindromeThread.start();
		
		// wait for the three threads to complete
		// display digit count, upper count and whether the string is a palindrome or not
		try
		{
			DigitCountThread.join();
			upperCountThread.join();
			isPalindromeThread.join();
		}
		catch(InterruptedException ignored)
		{
			//ignore 
		}
		System.out.println("Done with threads");
	}
}
