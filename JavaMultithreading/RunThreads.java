public class RunThreads 
{
	public static void main(String[] args)throws Exception
	{
		// creating two threads of ThreadA. ThreadA inherits from the Thread class
		ThreadA a1= new ThreadA("A");
		ThreadA a2= new ThreadA("AA");

		// creating two threads of ThreadB. ThreadB implements runnable interface
		ThreadB b= new ThreadB("B");
		Thread b1= new Thread(b);

		 b= new ThreadB("BB");
		Thread b2= new Thread(b);

		a2.start();
		a1.start();

		b1.start();
		b2.start();

        // wait here for all the threds to complete before moving forward
		try
		{
			a1.join();
			a2.join();
			b1.join();
			b2.join();
		}
		catch(InterruptedException ignored)
		{

		}

		System.out.println("Done with threads");
	}
}
