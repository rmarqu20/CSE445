import java.lang.Thread;
import java.util.*;

public class isPalindromeThread extends Thread
{
	private String str;
	private Boolean palindrome = true;
	
	public isPalindromeThread(String str)
	{
		this.str = str;
	}
	public void run()
	{
		int i = 0;
		int j = str.length() - 1;
		while(i < j)
		{
			if(str.charAt(i) != str.charAt(j))
            {
            	palindrome = false;
            	break;
            }
			i++;
			j--;
        }
        System.out.println("Palindrome: " + palindrome);
	}
}
