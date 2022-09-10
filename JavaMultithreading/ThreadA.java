import java.lang.Thread;

public class ThreadA extends Thread
{
	private String name;

	public ThreadA(String name)
	{
		this.name=name;
	}

	public void run()
	{
	   System.out.println("hello from :" + name);
	}
}
