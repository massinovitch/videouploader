using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoUploaderDAO.Util
{
    /**
     * IMPORTANT: IL NE FAUT PAS SUPPRIMER LES ESPACES RAJOUTES AU APPEND
     * 
    **/
    class SelectBuilder
    {
        private StringBuilder whereClause;
        private StringBuilder additionalClauses;

        public enum OperatorEnum {
        OR, AND, NOT, IN, WHERE, LIKE, BETWEEN, ORDER_BY}

        public SelectBuilder()
        {
            whereClause = new StringBuilder();
            whereClause.Append(" ").Append(OperatorEnum.WHERE.ToString());
            additionalClauses = new StringBuilder();
        }

        //Ajouter l'opérateur AND
        public void And()
        {
            if (additionalClauses.Length != 0)
            {
                additionalClauses.Append(" ").Append(OperatorEnum.AND.ToString());
            }  
        }

        //Ajouter l'opérateur OR
        public void Or()
        {
            if (additionalClauses.Length != 0)
            {
                additionalClauses.Append(" ").Append(OperatorEnum.OR.ToString()).Append(" ");
            }            
        }

        //Ajouter un critère de recherche champ='valeur'
        private void Search(String field, String value)
        {
            additionalClauses.Append(" ").Append(field).Append(" =").Append("'").Append(value).Append("'");
        }

        //Ajouter un critère de recherche champ like '%valeur%'
        private void SearchLike(String field, String value)
        {
            additionalClauses.Append(" ").Append(field).Append(" ").Append(OperatorEnum.LIKE.ToString()).Append(" '").Append("%").Append(value).Append("%").Append("'");
        }

        //recherche avec l'opérateur IN
        public void InSearch(String field, String[] values)
        {
            if (values != null && values.Length > 0)
            {
                additionalClauses.Append(" ").Append(field).Append(" ").Append(OperatorEnum.IN.ToString());
                OpenParenthese();
                for (int i = 0; i < values.Length; i++)
                {
                    additionalClauses.Append("'").Append(values[i]).Append("'");
                    if (i != values.Length - 1)
                    {
                        additionalClauses.Append(",");
                    }
                }
                CloseParenthese();
            }
        }

        //recherche avec l'opérateur NOT IN
        public void NotInSearch(String field, String[] values)
        {
            additionalClauses.Append(" ").Append(OperatorEnum.NOT.ToString());
            InSearch(field,values);
        }

        // recherche entre deux date ajouté avec un "AND"
        public void AndSearchBetween(String field, String dateDebut, String dateFin)
        {
            AndSearchAfter(field,dateDebut);
            AndSearchBefore(field,dateFin);
        }

        // recherche entre deux date ajouté avec un "OR"
        public void OrSearchBetween(String field, String dateDebut, String dateFin)
        {
            OrSearchAfter(field, dateDebut);
            AndSearchBefore(field, dateFin);
        }

        // exclure des éléements entre deux date attaché avec un "AND"
        public void AndSearchNotBetween(String field, String dateDebut, String dateFin)
        {
            AndSearchBefore(field,dateDebut);
            AndSearchAfter(field, dateFin);
        }

        // exclure des éléements entre deux date attaché avec un "OR"
        public void OrSearchNotBetween(String field, String dateDebut, String dateFin)
        {
            OrSearchBefore(field, dateDebut);
            AndSearchAfter(field, dateFin);
        }

        //recherche des élements jusqu'à certaine date avec AND
        public void AndSearchBefore(String field, String date)
        {
            if (additionalClauses.Length != 0)
            {
                And();
            }
            additionalClauses.Append(" ").Append(field).Append(" <= '").Append(date).Append("'");
        }

        //recherche des élements à partir d'une date avec AND
        public void AndSearchAfter(String field, String date)
        {
            if (additionalClauses.Length != 0)
            {
                And();
            }
            additionalClauses.Append(" ").Append(field).Append(" >= '").Append(date).Append("'");
        }

        //recherche des élements jusqu'à certaine date avec Or
        public void OrSearchBefore(String field, String date)
        {
            if (additionalClauses.Length != 0)
            {
                Or();
            }
            additionalClauses.Append(" ").Append(field).Append(" <= '").Append(date).Append("'");
        }

        //recherche des élements à partir d'une date avec Or
        public void OrSearchAfter(String field, String date)
        {
            if (additionalClauses.Length != 0)
            {
                Or();
            }
            additionalClauses.Append(" ").Append(field).Append(" >= '").Append(date).Append("'");
        }

        //ouvrir une parenthèse
        public void OpenParenthese()
        {
            additionalClauses.Append("(");
        }

        //fermer une parenthèse
        public void CloseParenthese()
        {
            additionalClauses.Append(")");
        }

        //recherche avec AND
        public void AndSearch(String field, String value)
        {
            if (additionalClauses.Length != 0)
            {
                And();
            }
            Search(field,value);
        }

        //recherche avec AND et LIKE
        public void AndSearchLike(String field, String value)
        {
            if (additionalClauses.Length != 0)
            {
                And();
            }
            SearchLike(field, value);
        }

        //recherche avec OR
        public void OrSearch(String field, String value)
        {
            if (additionalClauses.Length != 0)
            {
                Or();
            }
            Search(field, value);
        }

        //recherche avec OR et LIKE
        public void OrSearchLike(String field, String value)
        {
            if (additionalClauses.Length != 0)
            {
                Or();
            }
            SearchLike(field, value);
        }

        //Ajout du Tri
        public void OrderBy(String field)
        {
            if (additionalClauses.Length != 0)
            {
                additionalClauses.Append(" ").Append(OperatorEnum.ORDER_BY.ToString()).Append(" ").Append(field);
            }
        }

        // renvoi de la requête finale 
        public String getQueryString()
        {
            //vérification si aucun critère n'a été rajouté, on renvoie la from sans le "WHERE"
            if (additionalClauses.Length==0)
            {
                return "";
            }
            return whereClause.Append(additionalClauses).ToString();
        }
    }
}
