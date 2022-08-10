#include <iostream>
#include <deque>
#include <vector>
#include <list>
#include <stack>
#include <queue>

using namespace std;

template<typename T, typename Container = deque<T>>
class Queue
{
public:
	Queue() {}
	~Queue() {}

	void push(const T& value)
	{
		d.push_back(value);
	}

	void pop()
	{
		d.pop_front();
	}

	const T& front()
	{
		return d.front();
	}

	const T& back()
	{
		return d.back();
	}

private:
	Container d;
};

int main()
{
	Queue<int> q;
	q.push(1);
	q.push(2);
	q.push(3);
	q.push(4);

	cout << q.back() << endl; // 4
	cout << q.front() << endl; // 1

	q.pop();

	cout << q.back() << endl; // 4
	cout << q.front() << endl; // 2

	return 0;
}