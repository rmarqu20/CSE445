import java.lang.Thread;
import java.util.*;

public class DigitCountThread extends Thread
{
	private String str;
	private int digits = 0;
	
	public DigitCountThread(String str)
	{
		this.str = str;
	}
	public void run()
	{
		for(int i = 0; i < str.length(); i++) 
		{
            if(str.charAt(i) >= 48 && str.charAt(i) <= 57)
            {
            	digits++;
            }
        }
        System.out.println("Digit Count: " + digits);
	}
}
