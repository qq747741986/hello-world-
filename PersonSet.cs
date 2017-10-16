using System;
using System.Collections;
namespace C投票系统
{
	public class PersonSet
	{


		//hkukghk
		public Person[] _element;    //数组
		public int _capacity;        //数组容量
		public int _size;            //实际人数 
		public Person _person;

		//		默认构造函数
		public PersonSet (int max_size=4)
		{
			_capacity = 4;
			_size = 0;
			_element=new Person[_capacity];
		}


		//添加成员
		public void  add()
		{
			Console.WriteLine ("请输入name：");
			string sum1 = Console.ReadLine ();
			Console.WriteLine ("请输入salary：");
			int  sum2 = Convert.ToInt32( Console.ReadLine ());
			Console.WriteLine ("——————————————————————————————————————");
			Person aPerson = new Person (sum1, sum2);
			if (_size == _capacity)
			{
				Person[] temp = _element;
				_element = new Person[_capacity * 2];
				for (int i = 0; i < _capacity; i++)
				{
					_element [i] = temp [i];
				}
				_capacity *= 2;
			}
			_element [_size++] = aPerson;
		}


		//		插入学生信息
		public void charu()
		{
			Console.WriteLine ("输入要插入的位置");
			int p =Convert.ToInt32( Console.ReadLine ());
			if (p == _size)
			{
				add ();
			} 
			else if (p < _size && p > 0) 
			{

				for (int i = 0; i < _size; i++)
				{	
					if (_size == _capacity)
					{
						Person[] temp = _element;
						_element = new Person[_capacity * 2];
						for (int l = 0; l < _capacity; l++)
						{
							_element [l] = temp [l];
						}
						_capacity *= 2;
					}
					if (p == (i+1)) 
					{
						int j = _size;
						while (j !=i) 
						{
							_element [j] = _element [j - 1];
							j--;
						}
						Console.WriteLine ("请输入name：(输入0退出)");
						string sum1 = Console.ReadLine ();
						Console.WriteLine ("请输入salary：");
						int  sum2 = Convert.ToInt32( Console.ReadLine ());
						Console.WriteLine ("——————————————————————————————————————");
						Person aPerson = new Person (sum1, sum2);
						aPerson.print ();
						_element [j] = aPerson;
						_size++;
					}
				}
			}
		}

		//删除成员
		public void RemoveElement()
		{
			if (_size <= 0)
			{
				Console.WriteLine ("没有成员可以删除！！！");
				return;
			} else
			{
				_size--;
				_element [_size].print ();
				if (_size <= _capacity / 2) 
				{
					Person[] temp = _element;
					_element = new Person[_capacity / 2];
					for (int i = 0; i < _size; i++)
					{
						_element [i] = temp [i];
					}
					_capacity /= 2;
				}
			}
		}

		//删除任意一个成员
		public void RemoveElementid()
		{
			Console.WriteLine ("请输入要删除的数的ID");
			string p=Console.ReadLine ();
			if (p == _element [_size - 1].id)
			{
				RemoveElement ();
			} 
			else
			{
				int i;
				for ( i = 0; i < _size-1; i++)
				{
					if (p == _element [i].id)
					{
						_element [i].print ();
						for (; i < _size-1; i++) 
						{
							_element [i] = _element [i + 1];
						}
						_size--;
						return;
					}
				}
				if (i==_size-1)
				{
					Console.WriteLine ("找不到该ID，重新输入id");
					RemoveElementid ();
				}
			}
		}

		//按id查询任意一个成员

		public void  chaxun()
		{
			Console.WriteLine ("请输入要查询的人的id：");
			string num = Console.ReadLine ();
			int i;
			for ( i = 0; i < _size; i++) 
			{
				if (num==_element[i].id) 
				{
					_element [i].print ();
					return;
				}
			}
			if (i == _size)
			{
				Console.WriteLine ("找不到这个id的人！！！,重新输入id");
				chaxun ();
			}
		}

		//修改某一成员的信息

		public void xiugai()
		{
			int i;
			Console.WriteLine ("请输入要修改成员的id");
			string num = Console.ReadLine ();
			for ( i = 0; i < _size; i++)
			{
				if (num==_element[i].id)
				{
					Console.WriteLine ("请输入name：");
					string sum1 = Console.ReadLine ();
					Console.WriteLine ("请输入salary：");
					int  sum2 = Convert.ToInt32( Console.ReadLine ());
					_element [i].SetPerson(sum1,sum2);
					return;
				}
			}
			if (i == _size)
			{
				Console.WriteLine ("找不到这个id的人！！！,重新输入id");
				xiugai ();
			}
		}


		// 打印所有成员信息
		public void print()
		{
			for (int i = 0; i < _size; i++)
			{
				_element [i].print();
				Console.WriteLine ("——————————————————————————————————————————");
			}
		}

	}
}

