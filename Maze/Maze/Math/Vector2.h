#pragma once
class Vector2
{
public:
	Vector2();
	Vector2(float x, float y);
	~Vector2();

	Vector2 operator+(const Vector2& value);
	Vector2 operator-(const Vector2& value);

	Vector2& operator+=(const Vector2& value);
	Vector2& operator-=(const Vector2& value);

	Vector2 operator*(const float& value);

	Vector2& operator=(const Vector2& value);

	bool operator==(const Vector2& value);
	bool operator!=(const Vector2& value);

public:
	float _x = 0.0f;
	float _y = 0.0f;
};

