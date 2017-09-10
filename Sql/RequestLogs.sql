create table RequestLogs(
	 Id			uniqueidentifier	primary key,
	 [Url]		nvarchar(256)		not null,
	 Method		nvarchar(8)			not null,
	 Body		nvarchar(max)		null,
	 [Time]		datetime			not null
)