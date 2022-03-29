USE timbervaledb;
SELECT m.moveID, m.moveName, em.enemyID FROM move m 
	JOIN enemy_moves em ON m.moveID = em.moveID	
    WHERE em.enemyID = 10;