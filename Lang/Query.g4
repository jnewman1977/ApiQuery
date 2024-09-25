grammar Query;

query: expression (',' expression)* (sort)?;

expression: field operator value;

sort: 'SORT BY' sortField (',' sortField)*;

sortField: field ('ASC' | 'DESC')?;

field: IDENTIFIER;
operator: '=' | '>' | '<' | '>=' | '<=' | '!=' | 'LIKE';
value: STRING | NUMBER;

IDENTIFIER: [a-zA-Z_][a-zA-Z_0-9]*;
STRING: '"' (~["\\] | '\\' .)* '"';
NUMBER: [0-9]+ ('.' [0-9]+)?;

WS: [ \t\r\n]+ -> skip;