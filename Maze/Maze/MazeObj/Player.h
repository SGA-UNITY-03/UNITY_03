#pragma once
class Player
{
public:
	Player(shared_ptr<MazeObj> maze);
	~Player();

	void Update();
	void SetPos(Vector2 pos) { _pos = pos; }

	bool CanGo(Vector2 pos);
	Vector2 GetPos() { return _pos; }

private:
	Vector2 _pos;
	shared_ptr<MazeObj> _maze;

	Dir _direction = Dir::UP;
	vector<Vector2> _path;
	float _time = 0.0f;
	int _pathIndex = 0;
};

