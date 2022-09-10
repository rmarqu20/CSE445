import java.lang.Thread;

public class upperCountThread extends Thread
{
	private String str;
	private int uppers = 0;
	
	public upperCountThread(String str)
	{
		this.str = str;
	}
	public void run()
	{
		for(int i = 0; i < str.length(); i++) 
		{
			char c = str.charAt(i);
            if(Character.isUpperCase(c))
            {
            	uppers++;
            }
        }
        System.out.println("Uppercase Letter Count: " + uppers);
	}
}
