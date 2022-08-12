#include "framework.h"
#include "Player.h"

Player::Player(shared_ptr<MazeObj> maze)
{
	_maze = maze;
	_pos = _maze->GetStartPos();

	// �����
	Vector2 curPos = _pos;
	Vector2 destPos = _maze->GetEndPos();

	Vector2 frontDir[4] =
	{
		Vector2 {0, -1}, // UP
		Vector2 {-1, 0}, // LEFT
		Vector2 {0, 1}, // DOWN
		Vector2 {1, 0}, // RIGHT
	};

	while (curPos != destPos)
	{
		// 1. ���� �ٶ󺸴� ������ �������� ���������� �� �� �ִ��� Ȯ��
		int newDir = (_direction - 1 + Dir::DIRCOUNT) % Dir::DIRCOUNT;

		// 2. ���ƺ� �������� �� ���ִ��� Ȯ��
		// - �� �� �ִٸ� curPos ����
		// - �ٶ󺸰��ִ� ���� �ٲ��ֱ�
		// - path(��)�� ��ġ �߰�
		if (CanGo(curPos + frontDir[newDir]))
		{
			curPos += frontDir[newDir];
			_direction = static_cast<Dir>(newDir);

			_path.emplace_back(curPos);
		}

		// 3. ���ƺ� ���� �������� �� �� ���µ� ������ ������ ��������?
		else if (CanGo(curPos + frontDir[_direction]))
		{
			curPos += frontDir[_direction];

			_path.emplace_back(curPos);
		}

		// 4. ������ �����ְ� ������ �ȵ� => �������� ȸ��
		else
		{
			_direction = static_cast<Dir>((_direction + 1) % DIRCOUNT);
		}
	}

	// ����� ���� : Stack
	stack<Vector2> s;

	for (int i = 0; i < _path.size() - 1; i++)
	{
		if (s.empty() == false && s.top() == _path[i + 1])
			s.pop();
		else
			s.push(_path[i]);
	}
	s.push(_path.back());

	vector<Vector2> temp;
	while (true)
	{
		if (s.empty() == true)
			break;
		temp.push_back(s.top());
		s.pop();
	}

	std::reverse(temp.begin(), temp.end());

	_path.swap(temp);
}

Player::~Player()
{
	_maze = nullptr;
}

void Player::Update()
{
	if (_pathIndex >= _path.size())
		return;

	if (_time >= 0.7f)
	{
		_time = 0.0f;

		_pos = _path[_pathIndex];

		if (_pathIndex != 0)
		{
			Vector2 temp = _path[_pathIndex - 1];
			_maze->GetBlock(temp)->SetType(BlockType::ABLE);
			_maze->GetBlock(temp)->SetType(BlockType::FOOTPRINT);
		}

		_pathIndex++;
	}

	_time += 0.1f;
}

bool Player::CanGo(Vector2 pos)
{
	if (_maze->GetBlock(pos)->GetBlockType() == BlockType::DISABLE)
		return false;

	return true;
}
