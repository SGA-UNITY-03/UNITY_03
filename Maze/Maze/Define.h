#pragma once

#define WIN_WIDTH 1280
#define WIN_HEIGHT 720

#define CENTER_X 640
#define CENTER_Y 360

#define RED			 RGB(255,0,0)
#define GREEN		 RGB(0,255,0)
#define BLUE		 RGB(0,0,255)
#define WHITE		 RGB(255,255,255)
#define VIOLET		 RGB(138,43,226)

enum BlockType
{
	ABLE, // GREEN
	DISABLE, // RED
	PLAYER, // PUPLE
	END, // WHITE
	FOOTPRINT,
	NONE,
};

enum Dir
{
	UP,
	LEFT,
	DOWN,
	RIGHT,

	DIRCOUNT = 4
};
