// Algorithm.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
#include <deque>
#include <vector>
#include <list>
#include <stack>

using namespace std;
// Stack
template <typename T, typename Container = deque<T>>
class Stack
{
public:
	Stack() {}
	~Stack() {}

	void push(const T& value)
	{
		v.push_back(value);
	}

	void pop()
	{
		v.pop_back();
	}

	const T& top()
	{
		return v.back();
	}

	int size()
	{
		return v.size();
	}

private:
	Container v;
};

int main()
{
	Stack<int> s;
	s.push(1);
	s.push(2);
	s.push(3);
	s.push(4);

	cout << s.top() << endl;
	s.pop();
	cout << s.top() << endl;
}
