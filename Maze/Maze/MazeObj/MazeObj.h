#pragma once
class MazeObj
{
public:
	MazeObj();
	~MazeObj();

	void Update();
	void Render(HDC hdc);

	void CreateMaze();

	Vector2 GetStartPos() { return Vector2(1, 1); }
	Vector2 GetEndPos() { return Vector2(_poolCountX - 2, _poolCountY - 2); }

	shared_ptr<Block> GetBlock(Vector2 pos)
	{
		return _blockMatrix[static_cast<int>(pos._x)][static_cast<int>(pos._y)];
	}

private:
	const UINT _poolCountX = 25;
	const UINT _poolCountY = 25;

	vector<shared_ptr<Block>> _blocks; // 블록 만들기용
	shared_ptr<Block> _blockMatrix[25][25]; // 만든 후에 보기 편하기 위해 _blockMatrix[3][2]
	shared_ptr<class Player> _player;
};

