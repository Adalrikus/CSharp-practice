using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace linkedlist
{
	public class Linkedlist<T> where T : IComparable
	{
		public class Node
		{
			public T data;
			public Node prev;
			public Node next;
		}


		internal Node head;
		internal Node last;
		public int size = 0;
		public bool IsEmpty()
		{
			if(head == null && last == null)
				return true;
			else
				return false;
		}
		public void AddFirst(T newData)
		{
			if(last == null)
			{
				last = head;
				while(last.next != null)
					last = last.next;
			}
			Node newNode = new Node() { data = newData };
			newNode.next = head;
			newNode.prev = null;

			if(head != null)
				head.prev = newNode;
			
			head = newNode;
			size++;
		}
		public void AddLast(T newData)
		{
			Node newNode = new Node() { data = newData };
			
			if(head == null)
			{
				newNode.prev = null;
				head = newNode;
				size++;
			}
			else
			{
				if(last == null)
				{
					last = head;
					while(last.next != null)
						last = last.next;
				}
				last.next = newNode;
				newNode.prev = last;
				last = last.next;
				size++;
			}
		}
		public void Insert(Node prevNode, T newData)
		{
			if(prevNode == null)
				Console.WriteLine("Node can\'t be null");
			else
			{

				Node newNode = new Node() { data = newData };
				newNode.next = prevNode.next;
				prevNode.next = newNode;
				newNode.prev = prevNode;

				if(newNode.next != null)
					newNode.next.prev = newNode;
				
				size++;
			}
		}
		public void RemoveFirst()
		{
			if (size > 0)
			{
				head = head.next;
				head.prev = null;
				size--;
			}
			else
			{
				Console.WriteLine("No elements");
			}
		}
		public void RemoveLast()
		{
			Node temp = head;
			while (temp.next != last)
			{
				temp = temp.next;
			}
			temp.next = null;
			last = temp;
			size--;
		}
		public Node Find(T target)
		{
			Node temp = head;
			while (temp != null && temp.data.CompareTo(target) != 0)
			{
				temp = temp.next;
			}
			return temp;
		}
		public void Delete(Node prevNode)
		{
			if(prevNode == null)
			{
				Console.WriteLine("Node can\'t be null");
			}
			else
			{
				if(prevNode.next.next != null)
				{
					prevNode.next = prevNode.next.next;
					prevNode.next.prev = prevNode;
				}
				else
				{
					prevNode.next = null;
					last = prevNode;
				}
				
				size--;
			}
		}
		public void PrintNode()
		{
			Node temp = head;
			while (temp != null)
			{
				Console.WriteLine(temp.data);
				temp = temp.next;
			}
		}
		public void Reverse(Node root)
		{
			Node current = root, previous = null, next = null;
			while (current != null)
			{
				next = current.next;
				current.next = previous;
				previous = current;
				current = next;
			}
			head = previous;
		}
	}

	class Program
	{
		static Linkedlist<double> Input(Linkedlist<double> list)
		{
			Console.Write("1. From console\n2. From file\nChoose: ");
			int ch = Convert.ToInt32(Console.ReadLine());
			if(ch == 1)
			{
				Console.Write("Number of elements: ");
				int numEl = Convert.ToInt32(Console.ReadLine());
				for(int i = 0; i < numEl; i++)
				{
					Console.Write("Element: ");
					list.AddLast(Convert.ToDouble(Console.ReadLine()));
				}
				return list;
			}
			else if(ch == 2)
			{
				Console.Write("Input a path of a file: ");
				string path = Console.ReadLine();
				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();
				string line;
				System.IO.StreamReader file = new System.IO.StreamReader(path);
				while((line = file.ReadLine()) != null)
					list.AddLast(Convert.ToDouble(line));
				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				Console.WriteLine("RunTime of an input: " + elapsedTime);
				return list;
			}
			else
			{
				Console.WriteLine("Error: choose from 1/2");
				return list;
			}
		}


		static Linkedlist<double> Edit(Linkedlist<double> list)
		{
			Console.Write("1. Add an element\n2. Remove an element\nChoose: ");
			int ch = Convert.ToInt32(Console.ReadLine());

			if(ch == 1)
			{
				Console.Write("1. From beginning\n2. From inside\n3. From back\nChoose: ");
				ch = Convert.ToInt32(Console.ReadLine());
				switch(ch)
				{
					case 1:
						Console.Write("Element: ");
						double element1 = Convert.ToDouble(Console.ReadLine());
						Stopwatch stopWatch1 = new Stopwatch();
						stopWatch1.Start();
						list.AddFirst(element1);
						stopWatch1.Stop();
						TimeSpan ts1 = stopWatch1.Elapsed;
						string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts1.Hours, ts1.Minutes, ts1.Seconds, ts1.Milliseconds / 10);
						Console.WriteLine("RunTime of an input: " + elapsedTime1);
						break;
					case 2:
						Console.Write("After which element: ");
						double target = Convert.ToDouble(Console.ReadLine());
						Console.Write("Element: ");
						double element2 = Convert.ToDouble(Console.ReadLine());
						Stopwatch stopWatch2 = new Stopwatch();
						stopWatch2.Start();
						list.Insert(list.Find(target), element2);
						stopWatch2.Stop();
						TimeSpan ts2 = stopWatch2.Elapsed;
						string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds / 10);
						Console.WriteLine("RunTime of an input: " + elapsedTime2);
						break;
					case 3:
						Console.Write("Element: ");
						double element3 = Convert.ToDouble(Console.ReadLine());
						Stopwatch stopWatch3 = new Stopwatch();
						stopWatch3.Start();
						list.AddLast(element3);
						stopWatch3.Stop();
						TimeSpan ts3 = stopWatch3.Elapsed;
						string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts3.Hours, ts3.Minutes, ts3.Seconds, ts3.Milliseconds / 10);
						Console.WriteLine("RunTime of an input: " + elapsedTime3);
						break;
					default:
						break;
				}
				return list;
			}
			else if(ch == 2)
			{
				Console.Write("1. From beginning\n2. From inside\n3. From back\nChoose: ");
				ch = Convert.ToInt32(Console.ReadLine());
				switch(ch)
				{
					case 1:
						Stopwatch stopWatch4 = new Stopwatch();
						stopWatch4.Start();
						list.RemoveFirst();
						stopWatch4.Stop();
						TimeSpan ts4 = stopWatch4.Elapsed;
						string elapsedTime4 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts4.Hours, ts4.Minutes, ts4.Seconds, ts4.Milliseconds / 10);
						Console.WriteLine("RunTime of removing an element: " + elapsedTime4);
						break;
					case 2:
						Console.Write("After which element: ");
						double target = Convert.ToDouble(Console.ReadLine());
						Stopwatch stopWatch5 = new Stopwatch();
						stopWatch5.Start();
						list.Delete(list.Find(target));
						stopWatch5.Stop();
						TimeSpan ts5 = stopWatch5.Elapsed;
						string elapsedTime5 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts5.Hours, ts5.Minutes, ts5.Seconds, ts5.Milliseconds / 10);
						Console.WriteLine("RunTime of removing an element: " + elapsedTime5);
						break;
					case 3:
						Stopwatch stopWatch = new Stopwatch();
						stopWatch.Start();
						list.RemoveLast();
						stopWatch.Stop();
						TimeSpan ts = stopWatch.Elapsed;
						string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
						Console.WriteLine("RunTime of removing an element: " + elapsedTime);
						break;
					default:
						break;
				}
				return list;
			}
			else
			{
				Console.WriteLine("Error: choose from 1/2");
				return list;
			}
		}


		static void Output(Linkedlist<double> list)
		{
			Console.Write("1. To console\n2. To file\nChoose: ");
			int ch = Convert.ToInt32(Console.ReadLine());
			if(ch == 1)
			{
				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();
				Console.WriteLine("List elements:");
				list.PrintNode();
				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				Console.WriteLine("RunTime of an output: " + elapsedTime);
			}
			else if(ch == 2)
			{
				Console.Write("Input a path of a file: ");
				string path = Console.ReadLine();
				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();
				string[] lines = new string[list.size];
				for(int i = 0; i < list.size; i++)
				{
					lines[i] = Convert.ToString(list.head.data);
					list.head = list.head.next;
				}
				System.IO.File.WriteAllLines(path, lines);
				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				Console.WriteLine("RunTime of an output: " + elapsedTime);
			}
			else
			{
				Console.WriteLine("Error: choose from 1/2");
			}
		}


		static void Main()
		{
			Linkedlist<double> list = new Linkedlist<double>();
			int choice = 0;
			while(choice != 4){
				Console.Write("1. Input\n2. Edit\n3. Output\n4. Exit\nChoose: ");
				choice = Convert.ToInt32(Console.ReadLine());
				switch(choice)
				{
					case 1:
						list = Input(list);
						Console.WriteLine("List elements:");
						list.PrintNode();
						break;
					case 2:
						list = Edit(list);
						Console.WriteLine("List elements:");
						list.PrintNode();
						break;
					case 3:
						Output(list);
						break;
					default:
						break;
				}
			}
		}
	}
}
