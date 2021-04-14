USE mtm2021;

-- DROP TABLE jobs;
-- CREATE TABLE jobs
-- (
--     id INT AUTO_INCREMENT NOT NULL, 
--     description VARCHAR(255),
--     price INT NOT NULL,
--     name VARCHAR(255),

--     PRIMARY KEY(id)
-- );

-- DROP TABLE contractors;
-- CREATE TABLE contractors
-- (
--     id INT AUTO_INCREMENT NOT NULL, 
--     name VARCHAR(255),
--     age INT NOT NULL,
--     salary INT NOT NULL,

--     PRIMARY KEY(id)
-- );

-- SELECT * FROM jobs

-- CREATE TABLE bids
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     jobId INT,
--     contractorId INT,

--     PRIMARY KEY (id),

--     FOREIGN KEY (jobId)
--         REFERENCES jobs (id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (contractorId)
--         REFERENCES contractors (id)
--         ON DELETE CASCADE
-- )

SELECT * FROM bids