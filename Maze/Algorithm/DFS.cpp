#include <iostream>
#include <vector>
#include <list>
#include <algorithm>

using namespace std;

// - ��ȸ ���
// DFS

// BFS

//       0 1 2 3 4 5 6 7
//
// 0	 X O X X O X X X
// 1	 O X O O O X X X
// 2	 X O X O X X X X
// 3	 X O O X O O X X
// 4	 O O X O X X X X
// 5	 X X X 0 X X X X
// 6     X X X X X X X O
// 7	 X X X X X X O X

vector<vector<bool>> adjacent2 = vector<vector<bool>>(8, vector<bool>(8, false));
vector<bool> visited = vector<bool>(8, false);

void CreateGraphByMatrix()
{
	adjacent2[0][1] = true;
	adjacent2[0][4] = true;

	adjacent2[1][0] = true;
	adjacent2[1][2] = true;
	adjacent2[1][3] = true;

	adjacent2[2][1] = true;
	adjacent2[2][3] = true;

	adjacent2[3][1] = true;
	adjacent2[3][2] = true;
	adjacent2[3][5] = true;

	adjacent2[4][0] = true;

	adjacent2[5][3] = true;

	// �ٱ� 2��
	adjacent2[6][7] = true;

	adjacent2[7][6] = true;
}

void DFS(int here)
{
	visited[here] = true;
	cout << "Visited : " << here << endl;
	for (int there = 0; there < 8; there++)
	{
		// here : 0 �� ��
		// there 3��... 
		// ���� �ȵǾ�����
		// 0�� 3�� ������ �Ǿ��ֳ�?
		if (adjacent2[here][there] == false)
			continue;

		// ���� �Ǿ�����.
		// �湮�� �Ǿ��ֳ�?
		// 3�� �湮�� �Ǿ��ֳ�?
		if (visited[there] == true)
			continue;

		DFS(there);
	}
}

void DFS_ALL()
{
	int count = 0;
	for (int i = 0; i < 8; i++)
	{
		visited[i];
		if (visited[i] == false)
		{
			DFS(i);
			count++;
		}
	}

	cout << "�ٱ� ����: " << count << endl;
}

int main()
{
	CreateGraphByMatrix();
	DFS_ALL();

	return 0;
}