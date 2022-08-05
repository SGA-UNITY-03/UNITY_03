#pragma once
class Block
{
public:
	Block();
	~Block();

	void Update();
	void Render(HDC hdc);

	void SetPosition(Vector2 pos);

private:
	Vector2 _pos;
	Vector2 _size = { 10,10 };
	
	HBRUSH _brush;
	HPEN _pen;
};

