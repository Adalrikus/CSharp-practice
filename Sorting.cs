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
		public Node SortedInsert(Node nodeRef, Node newNode, int choice)
		{
			Node current;
			if(choice == 1)
			{
				if(nodeRef == null)
					nodeRef = newNode;
				else if(nodeRef.data.CompareTo(newNode.data) >= 0)
				{
					newNode.next = nodeRef;
					newNode.next.prev = newNode;
					nodeRef = newNode;
				}

				else
				{
					current = nodeRef;
					while(current.next != null && current.next.data.CompareTo(newNode.data) < 0)
						current = current.next;

					newNode.next = current.next;

					if(current.next != null)
						newNode.next.prev = newNode;
			
					current.next = newNode;
					newNode.prev = current;
				}
			}
			else
			{
				if(nodeRef == null)
					nodeRef = newNode;
				else if(nodeRef.data.CompareTo(newNode.data) < 0)
				{
					newNode.next = nodeRef;
					newNode.next.prev = newNode;
					nodeRef = newNode;
				}

				else
				{
					current = nodeRef;
					while(current.next != null && current.next.data.CompareTo(newNode.data) >= 0)
						current = current.next;

					newNode.next = current.next;

					if(current.next != null)
						newNode.next.prev = newNode;
			
					current.next = newNode;
					newNode.prev = current;
				}
			}
			return nodeRef;
		}
		public Node InsertionSort(Node nodeRef, int choice)
		{
			Node sorted = null;
			Node current = nodeRef;
			while (current != null)
			{
				Node next = current.next;
				current.prev = current.next = null;
				sorted = SortedInsert(sorted, current, choice);
				current = next;
			}
			nodeRef = sorted;
			return nodeRef;
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
			Console.Write("1. From console\n2. From file\n3. Random number generator\nChoose: ");
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
				string line;
				System.IO.StreamReader file = new System.IO.StreamReader(path);
				while((line = file.ReadLine()) != null)
					list.AddLast(Convert.ToDouble(line));
				return list;
			}
			else if(ch == 3)
			{
				Console.Write("Number of elements: ");
				int numEl = Convert.ToInt32(Console.ReadLine());
				for(int i = 0; i < numEl; i++)
				{
					Random rnd = new Random();
					list.AddLast(Convert.ToDouble(rnd.Next(1, 99999)));
				}
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
						list.AddFirst(Convert.ToDouble(Console.ReadLine()));
						break;
					case 2:
						Console.Write("After which element: ");
						double target = Convert.ToDouble(Console.ReadLine());
						Console.Write("Element: ");
						double element = Convert.ToDouble(Console.ReadLine());
						list.Insert(list.Find(target), element);
						break;
					case 3:
						Console.Write("Element: ");
						list.AddLast(Convert.ToDouble(Console.ReadLine()));
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
						list.RemoveFirst();
						break;
					case 2:
						Console.Write("After which element: ");
						double target = Convert.ToDouble(Console.ReadLine());
						list.Delete(list.Find(target));
						break;
					case 3:
						list.RemoveLast();
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
				Console.WriteLine("List elements:");
				list.PrintNode();
			}
			else if(ch == 2)
			{
				Console.Write("Input a path of a file: ");
				string path = Console.ReadLine();
				string[] lines = new string[list.size];
				for(int i = 0; i < list.size; i++)
				{
					lines[i] = Convert.ToString(list.head.data);
					list.head = list.head.next;
				}
				System.IO.File.WriteAllLines(path, lines);
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
			while(choice != 5){
				Console.Write("1. Input\n2. Edit\n3. Output\n4. Insertion sort\n5. Exit\nChoose: ");
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
					case 4:
						Console.Write("1. Ascending\n2. Descending\nChoose: ");
						choice = Convert.ToInt32(Console.ReadLine());
						Stopwatch stopWatch = new Stopwatch();
						stopWatch.Start();
						list.head = list.InsertionSort(list.head, choice);
						TimeSpan ts = stopWatch.Elapsed;
						string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
						string path = "results.txt";
						string[] lines = new string[list.size+1];
						for(int i = 0; i < list.size; i++)
						{
							lines[i] = Convert.ToString(list.head.data);
							list.head = list.head.next;
						}
						lines[list.size] = "RunTime: " + elapsedTime + " Size: " + list.size;
						System.IO.File.WriteAllLines(path, lines);

						Console.WriteLine("List elements:");
						list.PrintNode();
						break;
					default:
						break;
				}
			}
		}
	}
}
