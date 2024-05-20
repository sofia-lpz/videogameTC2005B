create table dialogue(
    speaker varchar(50) NOT NULL,
    lineIndex SMALLINT NOT NULL DEFAULT 0,
    storyIndex SMALLINT NOT NULL DEFAULT 0,
    
    text varchar(200) NOT NULL,

    primary key (speaker, lineIndex)
) engine=myisam DEFAULT CHARSET=utf8mb4;


insert into dialogue (speaker, lineIndex, storyIndex, text) values 
('Narrator', 0, 'Your eyes flutter open, you''re awake suddenly'),
('Narrator', 1, 'Isn''t the magician suppoused to snap his fingers to wake you?'),

('COLOMETA', 0, '3... 2... 1...'),
('COLOMETA', 1, 'ah!'),
('COLOMETA', 2, 'Now boy, tell the audience...')
('COLOMETA', 3, '...Do you feel hypnotized?')

('Narrator', 2, )