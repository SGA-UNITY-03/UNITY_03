#include "framework.h"
#include "Block.h"

Block::Block()
{
	_brushes[0] = CreateSolidBrush(GREEN);
	_brushes[1] = CreateSolidBrush(RED);
	_brushes[2] = CreateSolidBrush(VIOLET);
	_brushes[3] = CreateSolidBrush(WHITE);
	_brushes[4] = CreateSolidBrush(RGB(0,0,0));

	_pens[0] = CreatePen(PS_SOLID, 1, GREEN);
	_pens[1] = CreatePen(PS_SOLID, 1, RED);
	_pens[2] = CreatePen(PS_SOLID, 1, VIOLET);
	_pens[3] = CreatePen(PS_SOLID, 1, WHITE);
	_pens[4] = CreatePen(PS_SOLID, 1, RGB(0,0,0));
}

Block::~Block()
{
}

void Block::Update()
{
}

void Block::Render(HDC hdc)
{
	switch (_type)
	{
	case BlockType::ABLE:
		SelectObject(hdc, _brushes[0]);
		SelectObject(hdc, _pens[0]);
		break;
	case BlockType::DISABLE:
		SelectObject(hdc, _brushes[1]);
		SelectObject(hdc, _pens[1]);
		break;
	case BlockType::PLAYER:
		SelectObject(hdc, _brushes[2]);
		SelectObject(hdc, _pens[2]);
		break;
	case BlockType::END:
		SelectObject(hdc, _brushes[3]);
		SelectObject(hdc, _pens[3]);
		break;
	case BlockType::NONE:
		SelectObject(hdc, _brushes[4]);
		SelectObject(hdc, _pens[4]);
		break;
	default:
		break;
	}

	// RECT ±×¸®±â
	float left		= _pos._x -	 (_size._x * 0.5f);
	float top		= _pos._y -	 (_size._y * 0.5f);
	float right		= _pos._x +	 (_size._x * 0.5f);
	float bottom	= _pos._y +	 (_size._y * 0.5f);

	Rectangle(hdc, left, top, right, bottom);
}

void Block::SetPosition(Vector2 pos)
{
	_pos = pos;
}
