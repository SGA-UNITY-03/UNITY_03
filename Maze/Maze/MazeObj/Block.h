#pragma once
class Block
{
public:
	Block();
	~Block();

	void Update();
	void Render(HDC hdc);

	void SetPosition(Vector2 pos);
	void SetType(BlockType type) { _type = type; }
	BlockType GetBlockType() { return _type; }

private:
	Vector2 _pos;
	Vector2 _size = { 15,15 };
	
	HBRUSH _brushes[5];
	HPEN _pens[5];

	BlockType _type = BlockType::ABLE;
};

