CREATE TABLE ����������
(
������� NVARCHAR (50) NOT NULL PRIMARY KEY,
��� NVARCHAR (50) NOT NULL,
���� NVARCHAR (15) NOT NULL,
������ NVARCHAR (MAX) NOT NULL,
)

ALTER TABLE [����������] 
ADD CONSTRAINT A1
CHECK ((���� = N'�������������' OR ���� = N'���������'))