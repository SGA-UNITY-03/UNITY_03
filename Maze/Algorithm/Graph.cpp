#include <iostream>
#include <vector>
#include <list>
#include <algorithm>

using namespace std;

// ����Ʈ ���
// Ư¡
// - ���� �����Ͱ� �������ٸ�,,,ù�� °���� ������ ��...
// => 0�� N�� °�� ����Ǿ��ֽ��ϱ�? -> n���� ��
// 
// 
// 0 - 1, 4
// 1 - 0, 2, 3, 4
// 2 - 1, 3
// 3 - 1 ,2, 4, 5
// 4 - 0, 1, 3
// 5 - 3

vector<vector<int>> adjacent = vector<vector<int>>(6);

// �ε��� ���
// Ư¡
//  - 0�� N�� °�� ����Ǿ��ֽ��ϱ�? -> O(1)�� ������� �� �� �ִ�.
//  - ����: �����͸� ���� �Ҵ��ؾߵȴ�.
// 
//       0 1 2 3 4 5
//
// 0	 X O X X O X
// 1	 O X O O O X
// 2	 X O X O X X
// 3	 X O O X O O
// 4	 O O X O X X
// 5	 X X X 0 X X

vector<vector<bool>> adjacent2 = vector<vector<bool>>(6, vector<bool>(6, false));

void CreateGraph()
{
	// 0 - 1, 4
	adjacent[0].push_back(1);
	adjacent[0].push_back(4);

	// 1 - 0, 2, 3, 4
	adjacent[1].push_back(0);
	adjacent[1].push_back(2);
	adjacent[1].push_back(3);
	adjacent[1].push_back(4);

	// 2 - 1, 3
	adjacent[2].push_back(1);
	adjacent[2].push_back(3);

	// 3 - 1 ,2, 4, 5
	adjacent[3].push_back(1);
	adjacent[3].push_back(2);
	adjacent[3].push_back(4);
	adjacent[3].push_back(5);

	// 4 - 0, 1, 3
	adjacent[4].push_back(0);
	adjacent[4].push_back(1);
	adjacent[4].push_back(3);

	// 5 - 3
	adjacent[5].push_back(3);
}
void CreateGraphByMatrix()
{
	adjacent2[0][1] = true;
	adjacent2[0][4] = true;
	
	adjacent2[1][0] = true;
	adjacent2[1][2] = true;
	adjacent2[1][3] = true;
	adjacent2[1][4] = true;

	adjacent2[2][1] = true;
	adjacent2[2][3] = true;

	adjacent2[3][1] = true;
	adjacent2[3][2] = true;
	adjacent2[3][4] = true;
	adjacent2[3][5] = true;

	adjacent2[4][0] = true;
	adjacent2[4][1] = true;
	adjacent2[4][3] = true;

	adjacent2[5][3] = true;
}


int main()
{
	CreateGraphByMatrix();

	// �׷����� 1, 3�̶� ����Ǿ��ֳ�??
	//for (auto& edge : adjacent[1])
	//{
	//	if (edge == 3)
	//		cout << "1,3 ����" << endl;
	//}

	// �׷����� 5, 2�� ������ �Ǿ��ֳ�?
	//if (find(adjacent[5].begin(), adjacent[5].end(), 2) != adjacent[5].end())
	//{
	//	cout << "5,2 ����" << endl;
	//}
	//else
	//	cout << "5,2 ������� ����" << endl;

	// 1�� 2�� ����Ǿ��ֳ�?
	if (adjacent2[1][5])
		cout << "1,5 ����" << endl;

	return 0;
}