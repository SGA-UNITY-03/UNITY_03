#include "framework.h"
#include "Block.h"

Block::Block()
{
	_brush = CreateSolidBrush(RED);
	_pen = CreatePen(PS_SOLID, 1, RED);
}

Block::~Block()
{
}

void Block::Update()
{
}

void Block::Render(HDC hdc)
{
	float left		= _pos._x -	 (_size._x * 0.5f);
	float top		= _pos._y -	 (_size._y * 0.5f);
	float right		= _pos._x +	 (_size._x * 0.5f);
	float bottom	= _pos._y +	 (_size._y * 0.5f);

	SelectObject(hdc, _brush);
	SelectObject(hdc, _pen);

	Rectangle(hdc, left, top, right, bottom);
}

void Block::SetPosition(Vector2 pos)
{
	_pos = pos;
}
