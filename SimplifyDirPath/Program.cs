using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDirPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int D = 5;

            // Number from where we 
            // want to find place value. 
            int N = 85932;

            Console.Write(placeValue(N, D));
            Console.ReadLine();
            return;

            string path = "/home/";
            Console.WriteLine(string.Format("Path: {0} | SimplePath: {1}", path, SimplifyPathNew(path)));
            path = "/../";
            Console.WriteLine(string.Format("Path: {0} | SimplePath: {1}", path, SimplifyPathNew(path)));
            path = "/home//foo/";
            Console.WriteLine(string.Format("Path: {0} | SimplePath: {1}", path, SimplifyPathNew(path)));
            path = "/a/./b/../../c/";
            Console.WriteLine(string.Format("Path: {0} | SimplePath: {1}", path, SimplifyPathNew(path)));
            path = "/";
            Console.WriteLine(string.Format("Path: {0} | SimplePath: {1}", path, SimplifyPathNew(path)));
            Console.ReadLine();
        }

        static int placeValue(int N, int num)
        {
            int total = 1, value = 0, rem = 0;
            while (true)
            {
                rem = N % 10;
                N = N / 10;

                if (rem == num)
                {
                    value = total * rem;
                    break;
                }

                total = total * 10;
            }
            return value;
        }

        public static string SimplifyPathNew(string path)
        {
            var pathSplit = path.Split('/');
            var directories = pathSplit.ToList();
            directories.RemoveAll(p => string.IsNullOrWhiteSpace(p));
            pathSplit.ToList().RemoveAll(p => string.IsNullOrWhiteSpace(p));
            var root = GetRoot(directories);
            var stack = new Stack<string>();
            foreach (var item in directories)
            {
                switch (item)
                {
                    case ".":
                        break;
                    case "..":
                        if (stack.Count != 0)
                            stack.Pop();
                        break;
                    default:
                        stack.Push(item);
                        break;
                }
            }
            if (stack.Count != 0 && stack.Peek() == "/")
                stack.Pop();
            var temp = Reverse(stack.ToArray<string>());
            var retVal = "/" + string.Join("/", temp);
            return retVal;
        }

        private static string GetRoot(List<string> pathSplit)
        {
            if (pathSplit.Count == 0)
                return "/";
            var root = pathSplit[0];
            if (root == ".." || root == ".")
                root = "/";
            return root;
        }
        public static string[] Reverse(string[] arr)
        {
            Array.Reverse(arr);
            return arr;
        }
    }
}
