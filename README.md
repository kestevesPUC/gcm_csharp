## Comandos:
dotnet aspnet-codegenerator controller -name NomeDoController -namespace NomeDoProjeto.Controllers -outDir Controllers -api

dotnet new class -n User -o Models


## Migrate:

- dotnet ef migrations add create_tables
- dotnet ef database update

## Docker
- docker run --name gestao_condominio   -e POSTGRES_DB=gestao_condominio   -e POSTGRES_USER=kesteves   -e POSTGRES_PASSWORD=123456   -p 5432:5432 -d postgres:latest

## Inserts
INSERT INTO condominium.address
(id, country, state, city, postal_cod, "number", complement)
VALUES(1, 'Brasil', 'MG', 'Belo Horizonte', '31515-232', 1266, NULL);

INSERT INTO condominium.area
(id, "name", description)
VALUES(1, 'Salão de Festas', 'Utilizado para festas e confraternizações');

INSERT INTO condominium.apartament
(id, "number", bloco, condominium_id)
VALUES(1, 103, 2, 1);
INSERT INTO condominium.apartament
(id, "number", bloco, condominium_id)
VALUES(3, 403, 1, 1);
INSERT INTO condominium.apartament
(id, "number", bloco, condominium_id)
VALUES(4, 101, 1, 1);
INSERT INTO condominium.apartament
(id, "number", bloco, condominium_id)
VALUES(5, 102, 1, 1);
INSERT INTO condominium.apartament
(id, "number", bloco, condominium_id)
VALUES(6, 1, 1, 1);
INSERT INTO condominium.apartament
(id, "number", bloco, condominium_id)
VALUES(7, 105, 1, 1);

INSERT INTO administration.profile
(id, "name", description)
VALUES(2, 'Morador', 'Pessoas que residem no condomínio');
INSERT INTO administration.profile
(id, "name", description)
VALUES(3, 'Porteiro', 'Faz o controle de entrada e saída de pessoas e veículos');
INSERT INTO administration.profile
(id, "name", description)
VALUES(1, 'Administrador', 'Tem acesso a tudo na aplicação');
INSERT INTO administration.profile
(id, "name", description)
VALUES(5, 'Visitante', 'Terá acesso liberado Durante um período estabelecido');
INSERT INTO administration.profile
(id, "name", description)
VALUES(7, 'Zelador', 'Responsável por dar manutenço');

INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(1, 'Kaio Gomes Esteves CorrÃªa', 'kesteves.dev@gmail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-05-03 19:47:09.656', NULL, 1, 1, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(12, 'Kaio Gomes', 'kaiogomesesteves@gmail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-05-15 21:33:09.344', NULL, 3, 1, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(13, 'Nelson', 'nelson@123.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '2025-05-20 19:22:15.691', NULL, 4, 2, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(14, 'Helen', 'Helen@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '2025-05-20 19:28:48.185', NULL, 5, 2, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(15, 'Pedro', 'pedro@teste.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '2025-05-26 21:58:49.298', NULL, 4, 1, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(16, 'teste', 'teste@mail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '2025-05-27 21:29:12.823', NULL, 6, 3, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(17, 'teste', 'teste@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '2025-05-31 15:00:13.470', NULL, 4, 2, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(18, 'Teste 2', 'teste2@mail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '2025-05-31 15:02:21.417', NULL, 7, 2, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(19, 'teste', 'Kaio.correa@teste.123', '46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5', '2025-05-31 15:31:37.415', NULL, NULL, 3, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(23, 'Kaio', 'teste@mail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-06-01 14:40:07.635', NULL, NULL, 5, NULL);
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(24, 'Kaio', 'teste@mail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-06-01 14:40:37.290', NULL, NULL, 5, '14258348686');
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(25, 'Kaio', 'teste@mail.com', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-06-01 15:18:51.187', NULL, NULL, 5, '14258348688');
INSERT INTO "user"."user"
(id, "name", email, "password", created_at, updated_at, apartment_id, profile_id, cpf)
VALUES(26, 'testete', 'teste', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', '2025-06-01 15:23:03.261', NULL, NULL, 5, '123456');